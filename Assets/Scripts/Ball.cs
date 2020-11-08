using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Platform platform;

    public float speed;

    GameManager gameManager;

    bool isStarted;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (isStarted)
        {
            if (transform.position.y < -5.3f) //мяч ниже платформы
            {
                isStarted = false;
                gameManager.DeathСomes();  //убираем сердечко
                StartBall();
            }
        }
        else
        {
            StartBall();
        }
    }

    void AddForceBall()
    {
       // Vector2 force = new Vector2(Random.Range(-5.0f, 5.0f), 1);
        Vector2 force = new Vector2(0, 1);

        rb.velocity = (force.normalized * speed);
        isStarted = true;
    }

    void StartBall()
    {
        Vector2 platformPosotion = platform.transform.position;
        Vector2 ballNewPosition = new Vector2(platformPosotion.x, platformPosotion.y + 0.4f);
        transform.position = ballNewPosition;

        if (gameManager.pauseActiv) // Во время проигрыша не разрешает запустить мяч
        {
            
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                AddForceBall();
            }
        }
    }
}
