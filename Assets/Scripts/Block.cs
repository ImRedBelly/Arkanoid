using UnityEngine;

public class Block : MonoBehaviour
{
    GameManager gameManager;
    LevelManager levelManager;

    [Tooltip("Количевство жизней")]public int health;
    public int point;
    
    public Sprite block;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        levelManager = FindObjectOfType<LevelManager>();

        levelManager.BlockCreated();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if(health == 1)
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
