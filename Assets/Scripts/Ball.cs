using UnityEngine;

public class Ball : MonoBehaviour
{
    GameManager gameManager;
    SpriteRenderer sp;


    public Rigidbody2D rb;
    public Platform platform;
    public Ball[] balls;


    public float speed;
    public bool isStarted;
    public bool isRevers = false;

    float yPosition;
    float xDelta;

    [Header("Explosive")]
    public ParticleSystem fuze;  // партикл горения фитиля 
    public Sprite bombBall;  // спрайт взрывного мяча
    public float explosiveRadius; // радиус 
    public bool explosive = false; 

    void Start()
    {
        platform = FindObjectOfType<Platform>();
        gameManager = FindObjectOfType<GameManager>();

        yPosition = transform.position.y;
        xDelta = transform.position.x - platform.transform.position.x;
    }

    void Update()
    {
        if (!isStarted)
        {
            StartBall();
        }
    }
    public void StartBall()
    {
        PositionBall();
        if (!gameManager.pauseActiv && Input.GetMouseButtonDown(0))
        {
            AddForceBall();
        }
    }
    public void PositionBall()
    {
        Vector2 platformPosotion = platform.transform.position;
        Vector2 ballNewPosition = new Vector2(platformPosotion.x + xDelta, yPosition);
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
                Destroy(gameObject);
            }
            else
            {
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
            platform.MahnetTrue();
            if (collision.gameObject.CompareTag("Platform"))
            {
                yPosition = transform.position.y;
                xDelta = transform.position.x - platform.transform.position.x;
                Restart();
            }
        }
        if (explosive)
        {
            ActivExplosive();
            if (collision.gameObject.CompareTag("Alien"))
            {
                ExplodeBall();
            }
        }
    }
    public void Dublicate()
    {
        Ball newBall = Instantiate(this);
        newBall.Restart();
        newBall.speed = speed;
        if (isRevers)
        {
            newBall.ActivateMagnet();
        }
        if (explosive)
        {
            //newBall.ExplodeBall();
            newBall.ActivExplosive();
            newBall.BomberBall();
        }
    }
    public void Speed(float factorSpeed)
    {
        speed *= factorSpeed;
        rb.velocity = rb.velocity.normalized * speed;
    }
    public void ExplodeBall()                       // метод поиска блоков при взрывном мяче! вызывается в Block           ИДИ В BLOCK
    {
        int layerMask = LayerMask.GetMask("Alien");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosiveRadius, layerMask);
        foreach (Collider2D col in colliders)
        {
            Block block = col.GetComponent<Block>();
            if (block.isNotDestroy)
            {
                Destroy(col.gameObject);
            }
            else
            {
                block.DestroyBlock();
            }
        }
    }
    public void BomberBall()          // метод который делаем мяч взрывной    
    {
        balls = FindObjectsOfType<Ball>();

        foreach (Ball ball in balls)
        {
            ball.sp = GetComponent<SpriteRenderer>();  // меняет картинку на бомбу
            ball.sp.sprite = bombBall;      
            ball.fuze.gameObject.SetActive(true); // включает фитиль
        }
    }
    public void ActivateMagnet()
    {
        isRevers = true;
    }
    public void ActivExplosive()
    {
        explosive = true;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosiveRadius);
    }
}
