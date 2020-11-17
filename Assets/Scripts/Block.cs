using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject[] pickupPrefab;
    public GameObject parcikleEffectPrefab;
    public Sprite[] alien;
    [Tooltip("Количевство жизней")]
    public int health;
    public int point;
    public int chance;
    public bool isNotDestroy;
    public bool isInvisible;


    SpriteRenderer spriteImage;
    GameManager gameManager;
    LevelManager levelManager;

    void Start()
    {
        chance = Random.Range(0, 100);
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
        if (health == 0)
        {
            DestroyBlock();
        }
        else
        {
            spriteImage.sprite = alien[health - 1];
        }
    }

    void DestroyBlock()
    {
        gameManager.AddScore(point);
        levelManager.BlockDestroyed();
        Destroy(gameObject);

        if(chance > 50)
        {
            if (pickupPrefab.Length != 0)
            {
                int randomPick = Random.Range(0, pickupPrefab.Length);
                Instantiate(pickupPrefab[randomPick], transform.position, Quaternion.identity);
            }
            
        }
        if (parcikleEffectPrefab != null)
        {
            Instantiate(parcikleEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
