using UnityEngine;

public class ExplosiveBall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            ApplyEffect();
            Destroy(gameObject);
        }
    }
    void ApplyEffect()            // пикап ищет все мячи и говорит им что они взрывный
    {
        Ball[] ball = FindObjectsOfType<Ball>();
        foreach (Ball balls in ball)
        {
            balls.ActivExplosive();   
            balls.BomberBall();            // меняет картинки всем и включает партикл фитиля
        }


    }
}
