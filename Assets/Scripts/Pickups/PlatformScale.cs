using System.Collections;
using UnityEngine;

public class PlatformScale : MonoBehaviour
{
    public Vector2 before;
    public Vector2 after;
    Platform platform;

    void Start()
    {
        platform = FindObjectOfType<Platform>();    
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
        platform.transform.localScale = scale;
    }
}
