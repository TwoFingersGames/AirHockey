using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalImage : MonoBehaviour
{
    private int screenHight;
    private void Start()
    {

        gameObject.SetActive(false);
        screenHight = Screen.height/200;
    }
    public void PlayerGoal()
    {
        gameObject.SetActive(true);
        StartCoroutine("GoalDown");
    }
    public void EnemyGoal()
    {
        gameObject.SetActive(true);
        StartCoroutine("GoalUp");
    }
    IEnumerator GoalDown()
    {
        gameObject.transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 0, 1));
        
        for(float i = screenHight; i > 0; i-=0.2f)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, i);
            yield return new WaitForSeconds(0.001f);
        }
        gameObject.SetActive(false);
    }
    IEnumerator GoalUp()
    {
        gameObject.transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1));
        
        for (float i = -screenHight; i < 0; i+=0.2f)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, i);
            yield return new WaitForSeconds(0.001f);
        }
        gameObject.SetActive(false);
    }
}
