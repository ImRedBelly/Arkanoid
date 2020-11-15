using UnityEngine;
using System.Collections.Generic;

public class CreateBall : MonoBehaviour
{
    Ball balls;
    Ball newBall;
    void Start()
    {
        balls = FindObjectOfType<Ball>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Platform"))
        {
            ApplyEffect();
        }
    }
    void ApplyEffect()
    {
        newBall = Instantiate(balls);
        newBall.Restart();
        Destroy(gameObject);
    }
}
