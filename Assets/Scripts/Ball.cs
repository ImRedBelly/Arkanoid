using UnityEngine;

public class Ball : MonoBehaviour
{
    GameManager gameManager;

    public Rigidbody2D rb;
    public Platform platform;
    public Ball[] balls;

    public float speed;
    public bool isStarted;
    public bool isRevers = false;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (!isStarted)
        {
            StartBall();
        }
        print(rb.velocity.magnitude);
    }

    public void StartBall()
    {
        PositionBall();

        if (!gameManager.pauseActiv)
        {
            if (Input.GetMouseButtonDown(0))
            {
                AddForceBall();
            }
        }
    }

    public void PositionBall()
    {
        Vector2 platformPosotion = platform.transform.position;
        Vector2 ballNewPosition = new Vector2(platformPosotion.x, platformPosotion.y + 0.5f);
        transform.position = ballNewPosition;
    }

    public void AddForceBall()
    {
        //Vector2 force = new Vector2(Random.Range(-5.0f, 5.0f), 1);
        Vector2 force = new Vector2(0, 1);
        rb.velocity = (force.normalized * speed);
        isStarted = true;
    }
    public void Restart()
    {
        isStarted = false;
        rb.velocity = Vector2.zero;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Down"))
        {
            balls = FindObjectsOfType<Ball>();
            if (balls.Length > 1)
            {
                print("он не один");
                Destroy(gameObject);
            }
            else
            {
                print("он один");
                isStarted = false;
                gameManager.DeathСomes();
                PositionBall();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isRevers)
        {
            if (collision.gameObject.CompareTag("Platform"))
            {
                Restart();
                isRevers = false;
            }
        }
    }
}
