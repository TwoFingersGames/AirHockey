
using UnityEngine;

public class MaxSpeed : MonoBehaviour
{
    [SerializeField] [Range(0f, 50f)] private float maxSpeed;
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb.velocity.magnitude >= maxSpeed)
        {
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        }
    }
}
