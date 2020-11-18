using UnityEngine;

public class HeathPoint : MonoBehaviour
{
    public int point;
    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Healing();
        }
    }
    void Healing()  
    {
        if (gameManager.health <= 6)
        {
            gameManager.health += point;
            gameManager.ControlHeart();
        }
    }
}
