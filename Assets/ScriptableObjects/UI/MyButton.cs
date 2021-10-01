using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MyButton : MonoBehaviour
{
    [SerializeField] private MyButtonData buttonData;
    Image image;
    Sprite sprite;
    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
        sprite = buttonData.Sprites[0];
        gameObject.name = buttonData.name;
    }
}
