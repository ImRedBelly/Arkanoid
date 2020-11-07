using UnityEngine;

public class Block : MonoBehaviour
{
    public Sprite block;
    [Tooltip("Количевство жизней")]
    public int health;
    public int point;
    public bool isNotDestroy;
    public bool isInvisible;

    GameManager gameManager;
    LevelManager levelManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        levelManager = FindObjectOfType<LevelManager>();
        levelManager.BlockCreated();
    }
    void Update()
    {
        if (isInvisible) 
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isNotDestroy)
        {
            isInvisible = false;
        }
        else
        {
            isInvisible = false;
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
}
