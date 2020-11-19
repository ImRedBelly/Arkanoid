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

    //IEnumerator SpeedBall()
    //{
    //    RatePlus(bonusSpeed);
    //    yield return new WaitForSeconds(3.0f);
    //    RateMinus(starSpeed);
    //}

    void RatePlus(float multiplier)
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        foreach(Ball ball in balls)
        {
            ball.Speed(multiplier);
        }
    } 
    //void RateMinus(float multiplier)
    //{
    //    for (int i = 0; i < ball.Length; i++)
    //    {
    //        ball[i].rb.velocity /= multiplier;
    //    }
    //}
}
