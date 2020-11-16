using UnityEngine;

public class PickupScore : MonoBehaviour
{
    public int points;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            ApplyEffect();
        }
    }
    void ApplyEffect()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.AddScore(points);
        Destroy(gameObject);
    }
}
