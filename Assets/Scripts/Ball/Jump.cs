
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] [Range(0f, 10f)] private float force;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            rb.velocity = rb.velocity + contact.normal * force * contact.normalImpulse;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            rb.velocity = rb.velocity + contact.normal * force * contact.normalImpulse;
            rb.AddForce(rb.velocity + contact.normal * force * contact.normalImpulse, ForceMode2D.Force);
        }
    }
}
