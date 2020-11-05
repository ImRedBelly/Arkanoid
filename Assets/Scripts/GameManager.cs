using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text point;
    int score;
    bool pauseActiv;
    void Awake()
    {
        GameManager[] gameManagers = FindObjectsOfType<GameManager>();
        for (int i = 0; i < gameManagers.Length; i++)
        {
            if (gameManagers[i].gameObject != gameObject)
            {
                Destroy(gameObject);
                break;
            }
        }
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (pauseActiv)
            {
                Time.timeScale = 1f;
                pauseActiv = false;
            }
            else
            {
                Time.timeScale = 0f;
                pauseActiv = true;
            }
        }
    }
    public void AddScore(int addScore)
    {
        score += addScore;
        point.text = "POINTS: " + score;
    }
}
