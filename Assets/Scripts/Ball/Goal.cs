
using UnityEngine;


public class Goal : MonoBehaviour
{
    private Gameplay gameplay;

    private void Awake()
    {
        gameplay = MonoBehaviour.FindObjectOfType<Gameplay>();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "PlDoors")
        {
            
            
            Destroy(gameObject);
            gameplay.Goal(0);

        }
        if (coll.gameObject.tag == "EnDoors")
        {
            
            
            Destroy(gameObject);
            gameplay.Goal(1);
        }
        if (Count.Player == Count.MaxCount|| Count.Enemy == Count.MaxCount)
        {
            
            Destroy(gameObject);
            gameplay.Finish();
        }
        

    }
}
