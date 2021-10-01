using UnityEngine.UI;
using UnityEngine;

public class SettingsPanel : MonoBehaviour
{
    private void Start()
    {
        Close();
    }
    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    
}
