
using UnityEngine;

public class Vibration1 : MonoBehaviour
{
    public AndroidJavaClass unityPlayer;
    public AndroidJavaObject currentActivity;
    public AndroidJavaObject vibrator;
    public AndroidJavaObject context;

    public AndroidJavaClass vibrationEffect;

    public bool initialized = false;
    public void Init()
    {
        if (initialized) return;



        unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
        context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");
        vibrationEffect = new AndroidJavaClass("android.os.VibrationEffect");

        initialized = true;
    }
    public void Vibrate(long milliseconds)
    {
        if (AndroidVersion >= 26)
        {
            AndroidJavaObject createOneShot = vibrationEffect.CallStatic<AndroidJavaObject>("createOneShot", milliseconds, -1);
            vibrator.Call("vibrate", createOneShot);

        }
        else
        {
            vibrator.Call("vibrate", milliseconds);
        }
    }
    public static int AndroidVersion
    {
        get
        {
            int iVersionNumber = 0;
            if (Application.platform == RuntimePlatform.Android)
            {
                string androidVersion = SystemInfo.operatingSystem;
                int sdkPos = androidVersion.IndexOf("API-");
                iVersionNumber = int.Parse(androidVersion.Substring(sdkPos + 4, 2).ToString());
            }
            return iVersionNumber;
        }
    }
}
