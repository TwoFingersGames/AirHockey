
using UnityEngine;
using UnityEngine.UI;

public class ButtonsLogic : MonoBehaviour
{
    [SerializeField] private Image[] images;
    [SerializeField] private Sprite[] sprites;
    private Settings settings;

    private void Awake()
    {
        settings = Component.FindObjectOfType<Settings>();
        images = gameObject.GetComponentsInChildren<Image>();
    }
    private void Start()
    {
        
    }
    /*public void Volume()
    {
        if((bool)settings.Get("volume"))
        {
            images[0].color = new Vector4(1, 1, 1, 1);
            images[1].color = new Vector4(1, 1, 1, 1);
            images[2].color = new Vector4(1, 1, 1, 1);
            images[3].color = new Vector4(1, 1, 1, 1);
        }
        else
        {
            images[0].color = new Vector4(1, 1, 1, 0.7f);
            images[1].color = new Vector4(1, 1, 1, 0.7f);
            images[2].color = new Vector4(1, 1, 1, 0.7f);
            images[3].color = new Vector4(1, 1, 1, 0.7f);
        }
    }*/
    public void Bloom()
    {
        if ((bool)settings.Get("bloom")) { images[0].sprite = sprites[0]; }
        else images[0].sprite = sprites[1];
    }
    public void Panini()
    {
        if ((bool)settings.Get("panini")) { images[1].sprite = sprites[2]; }
        else images[1].sprite = sprites[3];
    }
    public void Chromatic()
    {
        if ((bool)settings.Get("chromatic")) { images[2].sprite = sprites[4]; }
        else images[2].sprite = sprites[5];
    }
    public void Film()
    {
        if ((bool)settings.Get("film")) { images[3].sprite = sprites[6]; }
        else images[3].sprite = sprites[7];
    }
    public void Vibro()
    {
        if ((bool)settings.Get("vibro")) { images[4].sprite = sprites[8]; }
        else images[4].sprite = sprites[9];
    }
    public void Music()
    {
        if ((bool)settings.Get("music")) { images[5].sprite = sprites[10]; }
        else images[5].sprite = sprites[11];
    }
    public void Sound()
    {
        if ((bool)settings.Get("sound")) { images[6].sprite = sprites[12]; }
        else images[6].sprite = sprites[13];
    }
    public void Particle()
    {
        if ((bool)settings.Get("particle")) { images[7].sprite = sprites[14]; }
        else images[7].sprite = sprites[15];
    }
}
