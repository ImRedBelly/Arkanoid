using UnityEngine;

public class CreateBall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            ApplyEffect();
        }
    }
    void ApplyEffect()
    {
        Ball balls = FindObjectOfType<Ball>();
        balls.Dublicate();
    }
}
