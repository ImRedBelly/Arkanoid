using System.Collections;
using UnityEngine;

public class PlatformScale : MonoBehaviour
{
    public float timePickup;
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
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.time += timePickup;
        Platform platform = FindObjectOfType<Platform>();
        platform.transform.localScale = after;

    }
    IEnumerator SmallObject()
    {
        yield return new WaitForSeconds(7.0f);
        Platform platform = FindObjectOfType<Platform>();
        platform.transform.localScale = before;
        Destroy(gameObject);
    }
}
