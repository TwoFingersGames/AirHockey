
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static bool stop;
     
    private Vector2 _position;
    private Rigidbody2D _rb;
    private float _speed;
    private void Start()
    {
        stop = false;
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        _position = _rb.position;
        _speed = _rb.velocity.magnitude;
        
        if (stop) 
        {
            
            _rb.velocity = new Vector2(0,0); 
        }
    }
    public Vector2 GetPosition()
    {
        return _position;
    }
    public float GetSpeed()
    {
        return _speed;
    }

}
