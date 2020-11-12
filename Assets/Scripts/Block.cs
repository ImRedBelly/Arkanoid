using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject pickupPrefab;
    public GameObject parcikleEffectPrefab;
    public Sprite block;
    [Tooltip("Количевство жизней")]
    public int health;
    public int point;
    public bool isNotDestroy;
    public bool isInvisible;


    SpriteRenderer spriteImage;
    GameManager gameManager;
    LevelManager levelManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        levelManager = FindObjectOfType<LevelManager>();
        spriteImage = GetComponent<SpriteRenderer>();

        if (!isNotDestroy)
        {
            levelManager.BlockCreated();
        }
        if (isInvisible)
        {
            spriteImage.enabled = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (isInvisible)
        {
            spriteImage.enabled = true;
            isInvisible = false;
            return;
        }

        if (isNotDestroy)
        {
            return;
        }

        health--;
        if (health == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = block;
            return;
        }
        DestroyBlock();

    }
    void DestroyBlock()
    {
        gameManager.AddScore(point);
        levelManager.BlockDestroyed();
        Destroy(gameObject);
        if(pickupPrefab != null)
        {
            Instantiate(pickupPrefab, transform.position, Quaternion.identity);
            Instantiate(parcikleEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
