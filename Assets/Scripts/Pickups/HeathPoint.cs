using UnityEngine;

public class HeathPoint : MonoBehaviour
{
    GameManager gameManager;
    public int point;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Healing();
        }
    }
    void Healing()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (gameManager.health <= 6)
        {
            gameManager.health += point;
            gameManager.HeartPlus();
            gameManager.HeartMinus();
        }
        Destroy(gameObject);
    }
}
