using System.Collections;
using UnityEngine;

public class VibroCollision : MonoBehaviour
{
    Settings settings;
    
    private bool vibroStayActive;
    private void Start()
    {
        settings = Component.FindObjectOfType<Settings>();
        
        StartCoroutine("VibrationInit");
        vibroStayActive = false;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((bool)settings.Get("vibro"))
        {
            if (collision.gameObject.tag == "Ball")
            {

                Vibration.Vibrate(10);
            }
            else Debug.Log("you touch wall");

        }
        
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((bool)settings.Get("vibro"))
        {
            if (collision.gameObject.tag != "Ball")
            {
                StartCoroutine("VibroStay");
            }
            else Debug.Log("you touch ball");
            
        }
        
    }
   
    IEnumerator VibroStay()
    {
        if (!vibroStayActive)
        {
            vibroStayActive = true;
            yield return new WaitForSeconds(0.1f);
            
            Vibration.Vibrate(1);
            vibroStayActive = false;
        }
        

    }
    IEnumerator VibrationInit()
    {
        while (!Vibration.initialized)
        {
            Debug.Log("try Vibration Init");
            Vibration.Init();
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("Vibration Init");
    }
}

