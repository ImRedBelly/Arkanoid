﻿using UnityEngine;

public class PickupRevers : MonoBehaviour
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
        Ball ball = FindObjectOfType<Ball>();
        ball.isRevers = true;
        Destroy(gameObject);
    }
}
