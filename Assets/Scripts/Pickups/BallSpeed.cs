using UnityEngine;
using System.Collections;

public class BallSpeed : MonoBehaviour
{
    public float speed;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            FastObject();
            StartCoroutine(SlowObject());
        }
    }
    void FastObject()
    {
        Ball[] ball = FindObjectsOfType<Ball>();
        for (int i = 0; i < ball.Length; i++)
        {
            ball[i].rb.velocity *= speed;
        }


    }
    IEnumerator SlowObject()
    {
        yield return new WaitForSeconds(7.0f);
        Ball[] ball = FindObjectsOfType<Ball>();
        for (int i = 0; i < ball.Length; i++)
        {
            ball[i].rb.velocity /= speed;
        }
        Destroy(gameObject);
    }
}
