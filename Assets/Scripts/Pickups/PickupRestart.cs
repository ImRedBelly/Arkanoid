using UnityEngine;

public class PickupRestart : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            ApplyEffect();
            Destroy(gameObject);
        }
    }
    void ApplyEffect()
    {
        Ball[] ball = FindObjectsOfType<Ball>();
        foreach(Ball balls in ball)
        {
            balls.ActivateMagnet();
        }
        

    }
}
