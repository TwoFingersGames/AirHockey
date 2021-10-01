using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] [Range(30f, 100f)] private float force;
    private Camera mainCamera;
    private Rigidbody2D rb;
    private float screenHeight;
    private Vector2 direction;
    private Touch touch;
    private Vector2 worldPoint;
    private bool stop;
    private void Awake()
    {
        mainCamera = MonoBehaviour.FindObjectOfType<Camera>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        
        screenHeight = Screen.height;
        stop = true;

    }

    private void Touch()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)
            {
                stop = false;
                if (touch.position.y < screenHeight / 2)
                {
                    worldPoint = mainCamera.ScreenToWorldPoint(touch.position);

                }
                else
                {
                    worldPoint = new Vector2(mainCamera.ScreenToWorldPoint(touch.position).x, 0);

                }

            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (touch.position.y < screenHeight / 2)
                {
                    worldPoint = mainCamera.ScreenToWorldPoint(touch.position);

                }
                else
                {
                    worldPoint = new Vector2(mainCamera.ScreenToWorldPoint(touch.position).x, 0);

                }

            }
            if (touch.phase == TouchPhase.Ended)
            {

                stop = true;
            }
        }
    }

    private void Update()
    {
        Touch();
    }
    private void FixedUpdate()
    {
        if (stop)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            //direction = new Vector2(rb.transform.position.x, rb.transform.position.y) - worldPoint;
            direction = rb.position - worldPoint;
            
            rb.velocity = -direction * force;
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Handheld.Vibrate();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Handheld.Vibrate();
    }

}

