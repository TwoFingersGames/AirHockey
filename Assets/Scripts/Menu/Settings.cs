using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Settings : MonoBehaviour
{
    private Data data;
    private DefaultSettings defaultSettings;
    private Dictionary<string, object> settings;
    private void Awake()
    {
        data = new Data();
        defaultSettings = Component.FindObjectOfType<DefaultSettings>();
        defaultSettings.defaultSettings = new Dictionary<string, object>();
        defaultSettings.SetDefaultSettings();
        settings = new Dictionary<string, object>();
        Load();
        CheckSettings();
        Save();
    }
    private void Start()
    {
        
        
        
    }
    public void CheckSettings()
    {
        foreach (string key in defaultSettings.defaultSettings.Keys)
        {
            if (Get(key)==null)
            {
                Debug.Log(key + " not contain in settings");
                object value;
                defaultSettings.defaultSettings.TryGetValue(key, out value);
                settings.Add(key, value);
                
                object _value;
                settings.TryGetValue(key, out _value);
                Debug.Log("Add key: " + key + ", value " + (bool)_value);
            }
        }
    }
    public bool ContainsKey(string key)
    {
        return settings.ContainsKey(key);
    }
    public object Get(string name)
    {
        if (settings.ContainsKey(name))
        {
            settings.TryGetValue(name, out var value);
            return value;
        }
        else
        {
            Debug.Log("Settings not contain this data");
            return null;
        }
        
    }
    public void Add(string name, object value)
    {
        if (settings.ContainsKey(name))
        {
            settings[name] = value;
        }
        else
        {
            settings.Add(name, value);
        }
    }
    public void Save()
    {
        //settings
        data.SetData(settings);

        if (!Directory.Exists(Application.persistentDataPath + "/Saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
            Debug.Log("Create derictory /Saves");
        }

        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = File.Create(Application.persistentDataPath + "/Saves/save.tfg");
        bf.Serialize(stream, data);
        stream.Close();
        Debug.Log("Save file created");
    }
    public void Load()
    {
        try
        {
            if (File.Exists(Application.persistentDataPath + "/Saves/save.tfg"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream stream = File.Open(Application.persistentDataPath + "/Saves/save.tfg", FileMode.Open);
                data = (Data)bf.Deserialize(stream);
                stream.Close();
                Debug.Log("Data loaded");

                //settings
                settings = data.GetData();

                
                Debug.Log("File Loaded!");
            }
            else
            {
                //Default settings:
                
                CheckSettings();
                
                Debug.Log("File not exist. Please wait for Save new file!");
                Save();
            }
        }
        catch (FileNotFoundException e)
        {
            Debug.Log(e + "\nFile not exist. Please wait for Save new file!");
        }
    }
    
}
[Serializable]
public class Data
{
    private Dictionary<string, object> settings;
    public Dictionary<string, object> GetData()
    {
        return settings;
    }
    public void SetData(Dictionary<string, object> data)
    {
        settings = data;
    }
}
