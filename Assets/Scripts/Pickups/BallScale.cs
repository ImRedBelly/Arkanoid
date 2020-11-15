using System.Collections;
using UnityEngine;

public class BallScale : MonoBehaviour
{
    public Vector2 before;
    public Vector2 after;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            BigObject();
            StartCoroutine(SmallObject()); //Возвращает исходный размер и удаляет pickup
        }
    }
    void BigObject()
    {
        Ball ball = FindObjectOfType<Ball>();
        ball.transform.localScale = after;
    }
    IEnumerator SmallObject()
    {
        yield return new WaitForSeconds(7.0f);
        Ball ball = FindObjectOfType<Ball>();
        ball.transform.localScale = before;
        Destroy(gameObject);
    }
}
