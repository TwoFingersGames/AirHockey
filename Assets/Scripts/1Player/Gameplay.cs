using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Gameplay : MonoBehaviour
{
    private GoalImage goalImage;
    private Settings settings;
    [SerializeField] private int maxCount;
    public string gameId = "4196189";
    public string surfacingId = "Interstitial_Android";
    public bool testMode = true;
    private CountPanel countPanel;

    [Header("SpawnObjects")]
    public GameObject[] prefabs;
    [Header("SpawnPoints")]
    public Vector2[] spawnPoints;

    private GameObject[] targets;
    private float[] targetScale;
    private void Awake()
    {
        countPanel = MonoBehaviour.FindObjectOfType<CountPanel>();
        settings = Component.FindObjectOfType<Settings>();
        goalImage = Component.FindObjectOfType<GoalImage>();
    }
    private void Start()
    {
        
        Advertisement.Initialize(gameId, testMode);
        
        
        Level.Ready = false;
        
        
        Count.MaxCount = maxCount;
        countPanel.SetText(1, Count.Player.ToString());
        countPanel.SetText(0, Count.Enemy.ToString());
        targets = new GameObject[prefabs.Length];
        targetScale = new float[prefabs.Length];
        for (int i = 0; i < prefabs.Length; i++)
        {
            Drop(prefabs[i], spawnPoints[i], i);
        }

        
    }

    public void ShowAds()
    {
        Advertisement.Show(surfacingId);
        
        
    }
    public void Goal(int i)
    {
        StartCoroutine("Vibro");
        if (i == 0)
        {
            Count.Enemy++;
            goalImage.EnemyGoal();
            countPanel.SetText(i, Count.Enemy.ToString());
            spawnPoints[0].y = -2;
        }
        else
        {
            Count.Player++;
            goalImage.PlayerGoal();
            countPanel.SetText(i, Count.Player.ToString());
            spawnPoints[0].y = 2;
        }

        Level.Ready = false;
        Drop(prefabs[0], spawnPoints[0], 0);
    }

    public void Finish()
    {
        Level.Ready = false;
        if (Count.Enemy > Count.Player) { 
            
            Count.Player = 0;
            Count.Enemy = 0;
            Pause();
        }
        else 
        {
            Count.Player = 0;
            Count.Enemy = 0;
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); 
        }
        
        
        
        
    }

    IEnumerator UpScale(int j)
    {

        for (float i = 0.1f; i <= targetScale[j]; i += 0.01f)
        {
            targets[j].transform.localScale = new Vector2(i, i);
            yield return new WaitForSeconds(0.03f);
        }
        Level.Ready = true;
    }

    IEnumerator Vibro()
    {
        if ((bool)settings.Get("vibro"))
        {
            for (int i = 0; i < 3; i++)
            {
                Vibration.Vibrate(10);
                yield return new WaitForSeconds(0.05f);
            }
        }
        

    }

    private void Drop(GameObject prefab, Vector2 point,int i)
    {
        targetScale[i] = prefab.transform.localScale.x;
        prefab.transform.position = point;
        targets[i]=Instantiate(prefab, prefab.transform.position, prefab.transform.rotation);

        StartCoroutine("UpScale",i);
    }

    public void Pause()
    {
        ShowAds();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}

public static class Level
{
    public static bool Ready;
}
public static class Count
{
    public static int MaxCount;
    public static int Player;
    public static int Enemy;
}

