using UnityEngine;

public class Ball : MonoBehaviour
{
    public Ball[] balls;
    public Platform platform;

    GameManager gameManager;
    SpriteRenderer sp;
    Rigidbody2D rb;
    AudioSource audioSource;


    public float speed;
    public bool isStarted;
    public bool isRevers = false;

    float yPosition;
    float xDelta;

    [Header("Explosive")]
    public AudioClip explosiveModeSound;
    public ParticleSystem fuze;  // партикл горения фитиля 
    public Sprite bombBall;  // спрайт взрывного мяча
    public float explosiveRadius; // радиус 
    public bool explosive = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        
    }
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
        audioSource.Play();

        if (isRevers && collision.gameObject.CompareTag("Platform"))
        {
            yPosition = transform.position.y;
            xDelta = transform.position.x - platform.transform.position.x;
            Restart();
        }
        if (explosive && collision.gameObject.CompareTag("Alien"))
        {
            ExplosiveBall();
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
            newBall.ActivExplosive();
        }
    }
    public void Speed(float factorSpeed)
    {
        speed *= factorSpeed;
        rb.velocity = rb.velocity.normalized * speed;
    }
    public void ExplosiveBall()
    {
        int layerMask = LayerMask.GetMask("Alien");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosiveRadius, layerMask);
        foreach (Collider2D col in colliders)
        {
            Block block = col.GetComponent<Block>();
            block.DestroyBlock();
        }
    }
    public void ActivateMagnet()
    {
        isRevers = true;
    }
    public void ActivExplosive()
    {
        explosive = true;
        sp = GetComponent<SpriteRenderer>();
        sp.sprite = bombBall;
        fuze.gameObject.SetActive(true);
        audioSource.clip = explosiveModeSound;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosiveRadius);
    }
}
