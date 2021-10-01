using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GoToMenu : MonoBehaviour
{
    [SerializeField] private Sprite[] pauseSprites;
    private PauseButton pauseButton;
    private Image pauseImage;
    public GameObject ExitButton;
    public GameObject SettingsButton;
    public GameObject gameTitle;
    private bool open;
    private Vector2 ballVelocity;
    private Camera cam;
    private CameraHolder holder;
    [SerializeField][Range(-80, 0)] private float rotationAngle;
    private void Awake()
    {
        //fixDeltaTime = Time.fixedDeltaTime;
        cam = MonoBehaviour.FindObjectOfType<Camera>();
        holder = Component.FindObjectOfType<CameraHolder>();
        pauseButton = Component.FindObjectOfType<PauseButton>();
        pauseImage = pauseButton.gameObject.GetComponent<Image>();
        gameTitle = Component.FindObjectOfType<GameTitle>().gameObject;
        ExitButton.SetActive(false);
        SettingsButton.SetActive(false);
        gameTitle.SetActive(false);
    }
    private void Start()
    {
        open = false;
        
        
        


    }
    public void Menu()
    {
        if (open)
        {
            StartCoroutine("ReRotator", rotationAngle);
            pauseImage.sprite = pauseSprites[0];
            
        }
        else
        {
            
            StartCoroutine("Rotator", rotationAngle);
            pauseImage.sprite = pauseSprites[1];
            open = true;
        }
    }
    IEnumerator Rotator(float value)
    {
        Level.Ready = false;
        Ball.stop = true;
        
        //Time.fixedDeltaTime /= 5;
        cam.orthographic = false;
        for (float i = 0; i > value; i --)
        {
            holder.Rotate(i);
            yield return new WaitForSeconds(.001f);
        }
        if (holder.transform.rotation.eulerAngles.x != value)
        {
            holder.transform.rotation = Quaternion.Euler(value, 0, 0);
        }
        ExitButton.SetActive(true);
        SettingsButton.SetActive(true);
        gameTitle.SetActive(true);

    }
    IEnumerator ReRotator(float value)
    {
        SettingsButton.SetActive(false);
        ExitButton.SetActive(false);
        gameTitle.SetActive(false);
        for (float i = value; i < 0; i ++)
        {
            holder.Rotate(i);
            yield return new WaitForSeconds(.001f);
        }
        if (holder.transform.rotation.eulerAngles.x != 0)
        {
            holder.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
        
        
        cam.orthographic = true;
        open = false;
        //Time.fixedDeltaTime = fixDeltaTime;
        Level.Ready = true;
        Ball.stop = false;
        

    }

}
