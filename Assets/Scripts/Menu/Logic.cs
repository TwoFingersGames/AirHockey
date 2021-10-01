using UnityEngine;
public class Logic : MonoBehaviour
{
    [SerializeField]private Settings settings;
    [SerializeField]private SettingsPanel settingsPanel;
    [SerializeField]private EffectsLogic effectsLogic;
    [SerializeField]private ButtonsLogic buttonsLogic;
    
    private void Awake()
    {


        settings = Component.FindObjectOfType<Settings>();
        buttonsLogic = Component.FindObjectOfType<ButtonsLogic>();
        settingsPanel = Component.FindObjectOfType<SettingsPanel>();
        effectsLogic = Component.FindObjectOfType<EffectsLogic>();
    }
    private void Start()
    {
        
        
        
        
        ApplyLoad();
    }
    private void ApplyLoad()
    {


        settings.Add("volume", true);
        effectsLogic.SetVolumeActive((bool)settings.Get("volume"));
        effectsLogic.SetBloomActive((bool)settings.Get("bloom"));
        buttonsLogic.Bloom();
        effectsLogic.SetPaniniActive((bool)settings.Get("panini"));
        buttonsLogic.Panini();
        effectsLogic.SetChromaticActive((bool)settings.Get("chromatic"));
        buttonsLogic.Chromatic();
        effectsLogic.SetFilmActive((bool)settings.Get("film"));
        //UpdateVolumeActive();
        buttonsLogic.Film();
        buttonsLogic.Vibro();
        buttonsLogic.Music();
        buttonsLogic.Sound();
        buttonsLogic.Particle();

    }
    /*private void UpdateVolumeActive()
    {
        if (!(bool)settings.Get("bloom") &&
            !(bool)settings.Get("panini") &&
            !(bool)settings.Get("chromatic") &&
            !(bool)settings.Get("film"))
        {
            settings.Add("volume", false);
        }
        else
        {
            settings.Add("volume", true);
        }
        effectsLogic.SetVolumeActive((bool)settings.Get("volume"));
        buttonsLogic.Volume();
    }*/
    
    public void OpenSettings()
    {
        settingsPanel.Open();
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void SaveButton()
    {
        settings.Save();
        settingsPanel.Close();
    }
    public void SwichPanini()
    {
        if ((bool)settings.Get("panini"))
        {
            settings.Add("panini", false);
            effectsLogic.SetPaniniActive(false);
            
        }
        else
        {
            settings.Add("panini", true);
            //UpdateVolumeActive();
            effectsLogic.SetPaniniActive(true);
            
        }
        buttonsLogic.Panini();
        //UpdateVolumeActive();
    }
    public void SwichBloom()
    {
        if ((bool)settings.Get("bloom"))
        {
            effectsLogic.SetBloomActive(false);
            settings.Add("bloom", false);
        }
        else
        {
            
            //UpdateVolumeActive();
            effectsLogic.SetBloomActive(true);
            settings.Add("bloom", true);
        }
        buttonsLogic.Bloom();
        //UpdateVolumeActive();
    }
    public void SwichChromatic()
    {
        if ((bool)settings.Get("chromatic"))
        {
            effectsLogic.SetChromaticActive(false);
            settings.Add("chromatic", false);
        }
        else
        {
            settings.Add("chromatic", true);
            //UpdateVolumeActive();
            effectsLogic.SetChromaticActive(true);
            
        }
        buttonsLogic.Chromatic();
        //UpdateVolumeActive();
    }
    public void SwichFilm()
    {
        if ((bool)settings.Get("film"))
        {
            effectsLogic.SetFilmActive(false);
            settings.Add("film", false);
        }
        else
        {
            settings.Add("film", true);
            //UpdateVolumeActive();
            effectsLogic.SetFilmActive(true);
            
        }
        buttonsLogic.Film();
        //UpdateVolumeActive();
    }
    public void SwichVibro()
    {
        if ((bool)settings.Get("vibro"))
        {
            settings.Add("vibro", false);
        }
        else
        {
            settings.Add("vibro", true);
        }
        buttonsLogic.Vibro();
    }
    public void SwichMusic()
    {
        if ((bool)settings.Get("music"))
        {
            settings.Add("music", false);
        }
        else
        {
            settings.Add("music", true);
        }
        buttonsLogic.Music();
    }
    public void SwichSound()
    {
        if ((bool)settings.Get("sound"))
        {
            settings.Add("sound", false);
        }
        else
        {
            settings.Add("sound", true);
        }
        buttonsLogic.Sound();
    }
    public void SwichParticle()
    {
        if ((bool)settings.Get("particle"))
        {
            settings.Add("particle", false);
        }
        else
        {
            settings.Add("particle", true);
        }
        buttonsLogic.Particle();
    }
}