using UnityEngine;
using System.Collections;

public class BallScale : MonoBehaviour
{
    public Vector2 before;
    public Vector2 after;
    Ball[] ball;
    void Start()
    {
        ball = FindObjectsOfType<Ball>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            StartCoroutine(BigObject());
        }
    }

    IEnumerator BigObject()
    {
        Scale(after);
        yield return new WaitForSeconds(3.0f);
        Scale(before);
    }
    void Scale(Vector2 scale)
    {
        for (int i = 0; i < ball.Length; i++)
        {
            ball[i].transform.localScale = scale;
        }
    }
}
