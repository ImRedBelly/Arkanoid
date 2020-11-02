using UnityEngine;

public class Block : MonoBehaviour
{
    GameManager gameManager;

    public int health;
    public int point;
    
    public Sprite block;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
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
            gameManager.sumPoint += point;
            Destroy(gameObject);
        }
    }
}
