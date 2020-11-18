using UnityEngine;
using System.Collections;

public class BallSpeed : MonoBehaviour
{
    public float starSpeed;
    public float bonusSpeed;
    Ball[] ball;

    private void Start()
    {
        ball = FindObjectsOfType<Ball>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            StartCoroutine(SpeedBall());
        }
    }

    IEnumerator SpeedBall()
    {
        RatePlus(bonusSpeed);
        yield return new WaitForSeconds(3.0f);
        RateMinus(starSpeed);
    }

    void RatePlus(float multiplier)
    {
        for (int i = 0; i < ball.Length; i++)
        {
            ball[i].rb.velocity *= multiplier;
        }
    } 
    void RateMinus(float multiplier)
    {
        for (int i = 0; i < ball.Length; i++)
        {
            ball[i].rb.velocity /= multiplier;
        }
    }
}
