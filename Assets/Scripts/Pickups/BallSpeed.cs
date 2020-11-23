using UnityEngine;
using System.Collections;

public class BallSpeed : MonoBehaviour
{
    public float bonusSpeed;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            RatePlus(bonusSpeed);
        }
    }

    void RatePlus(float multiplier)
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach (Ball ball in balls)
        {
            ball.Speed(multiplier);
        }
    }
}
