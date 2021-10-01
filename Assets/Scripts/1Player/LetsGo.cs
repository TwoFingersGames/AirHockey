using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class LetsGo : MonoBehaviour
{
    private Image image;
    private void Start()
    {
        image = gameObject.GetComponent<Image>();
        StartCoroutine("Fade");
    }
    IEnumerator Fade()
    {
        for(float i = 1; i>0; i -= 0.01f)
        {
            image.color = new Vector4(1, 1, 1, i);
            yield return new WaitForSeconds(0.01f);
        }
        gameObject.SetActive(false);
    }
}
