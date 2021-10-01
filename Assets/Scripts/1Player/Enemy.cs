using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Vector2 maxForce, maxMovePower, maxHomeX, maxHomeY;

    private Ball ball;
    private Rigidbody2D rb;

    private float force, movePower;

    private Vector2 home, direction;

    private State state;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        ball = MonoBehaviour.FindObjectOfType<Ball>();

    }
    private void Update()
    {
        if (ball == null)
        {
            StartCoroutine("BallFinder");
        }
    }
    private void FixedUpdate()
    {
        if (Level.Ready)
        {
            if (rb.position.y <= 0)
            {
                rb.position = new Vector2(rb.position.x, 0);
            }

            SwitchState();
            ReturnHome();
            Defence();
            Atack();
        }
        else
        {
            state = State.ReturnToHome;
            ReturnHome();
        }
    }

    IEnumerator BallFinder()
    {
        while (ball == null)
        {
            ball = MonoBehaviour.FindObjectOfType<Ball>();
            yield return new WaitForSeconds(1f);
        }
    }

    private void Atack()
    {
        if (state == State.Atack)
        {
            force = Random.Range(maxForce.x, maxForce.y);
            direction = ball.GetPosition() - rb.position;

            rb.velocity = direction.normalized * force;

            Debug.Log("Атакую!!");
        }
    }
    private void ReturnHome()
    {
        if (state == State.ReturnToHome)
        {

            direction = home - rb.position;

            rb.velocity = direction * movePower;
            Debug.Log("Возвращаюсь!!");
        }

    }
    private void Defence()
    {
        if (state == State.Defence)
        {

            direction = new Vector2(ball.GetPosition().x / 2f, home.y) - rb.position;

            rb.velocity = direction * movePower;
            Debug.Log("Защищаю!!");
        }
    }
    private void SwitchState()
    {

        if (ball.GetPosition().y >= -0.1f && state != State.ReturnToHome)
        {
            state = State.Atack;
            Debug.Log("В атаку!!");
        }
        else if (ball.GetPosition().y < 0 || rb.position == new Vector2(home.x, home.y))
        {
            state = State.Defence;
            Debug.Log("В защиту!!");

        }
        else
        {
            //state = State.Atack;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        movePower = Random.Range(maxMovePower.x, maxMovePower.y);
        home = new Vector2(Random.Range(maxHomeX.x, maxHomeX.y), Random.Range(maxHomeY.x, maxHomeY.y));
        state = State.ReturnToHome;

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        state = State.ReturnToHome;
    }
    enum State
    {
        ReturnToHome,
        Defence,
        Atack
    }
}
