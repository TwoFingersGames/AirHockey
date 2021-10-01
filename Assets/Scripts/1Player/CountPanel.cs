using UnityEngine;
using UnityEngine.UI;

public class CountPanel : MonoBehaviour
{
    private Text[] texts;
    private void Awake()
    {
        texts = gameObject.GetComponentsInChildren<Text>();
    }
    public void SetText(int i, string text)
    {
        texts[i].text = text;
    }
    public string GetText(int i)
    {
        return texts[i].text;
    }
}
