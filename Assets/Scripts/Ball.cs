using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Platform platform;

    GameManager gameManager;

    public float speed;
    bool isStarted;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (isStarted)
        {
            if (transform.position.y < -5.3f)
            {
                isStarted = false;
                gameManager.DeathСomes();
                PositionBall();
            }
        }
        else
        {
            StartBall();
        }
    }
 
    void StartBall()
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

    private void PositionBall()
    {
        Vector2 platformPosotion = platform.transform.position;
        Vector2 ballNewPosition = new Vector2(platformPosotion.x, platformPosotion.y + 0.4f);
        transform.position = ballNewPosition;
    }

    void AddForceBall()
    {
        Vector2 force = new Vector2(Random.Range(-5.0f, 5.0f), 1);
        rb.velocity = (force.normalized * speed);
        isStarted = true;
    }
}
