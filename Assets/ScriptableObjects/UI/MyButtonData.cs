using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New MyButtonData", menuName = "MyButtonData", order = 51)]
public class MyButtonData : ScriptableObject
{
    [SerializeField] private string buttonName;
    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite[] sprites;
    public string ButtonName
    {
        get
        {
            return buttonName;
        }
    }
    public Image ButtonImage
    {
        get
        {
            return buttonImage;
        }
    }
    public Sprite[] Sprites
    {
        get
        {
            return sprites;
        }
    }

}
