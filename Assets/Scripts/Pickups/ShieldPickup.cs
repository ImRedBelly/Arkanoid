using System.Collections;
using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    public Shield shield;
    void Awake()
    {
        shield = Instantiate(shield,new Vector3(2f, -6.2f ,0f), Quaternion.identity);  // Пикап щита создает щит 

     //тут он его находит     ИДИ В SHIELD
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
        shield.Activ(!shield.activShild);   // при запуске корутины он включается на три секунды 
        yield return new WaitForSeconds(3.0f);
        shield.Activ(shield.activShild); // выключается
        Destroy(gameObject); // удаляется пикап
        Destroy(shield.gameObject); // удаляется щит
    }
}
