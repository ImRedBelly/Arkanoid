using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Text text;
    void Start()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        text.text = "Ваш счет: " + gameManager.score;
        gameManager.pauseActiv = false;
        Destroy(gameManager.gameObject);
    }


}
