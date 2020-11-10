using UnityEngine;

public class Block : MonoBehaviour
{
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
        isInvisible = false;
        if (!isInvisible)
        {
            spriteImage.enabled = true;
            return;
        }


        if (!isNotDestroy)
        {
            return;
        }

        health--;
        if (health == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = block;
        }
        else
        {
            gameManager.AddScore(point);
            levelManager.BlockDestroyed();
            Destroy(gameObject);
        }

    }
}
