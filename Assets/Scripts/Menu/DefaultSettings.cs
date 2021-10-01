using System.Collections.Generic;
using UnityEngine;

public class DefaultSettings : MonoBehaviour
{
    [SerializeField]
    private bool volume, bloom, panini, chromatic, film, vibro, sound, music, particle;
    private Settings settings;
    public Dictionary<string, object> defaultSettings;
    
    private void Awake()
    {
        
        
    }
    
        
    public void SetDefaultSettings()
    {
        defaultSettings.Add("volume", volume);
        defaultSettings.Add("bloom", bloom);
        defaultSettings.Add("panini", panini);
        defaultSettings.Add("chromatic", chromatic);
        defaultSettings.Add("film", film);
        defaultSettings.Add("vibro", vibro);
        defaultSettings.Add("sound", sound);
        defaultSettings.Add("music", music);
        defaultSettings.Add("particle", particle);
    }
    
}
