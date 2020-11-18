using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image[] heart;
    public Text pause;
    public Text restart;
    public Text point;

    public int score;
    public int health = 3;
    public float time;
    public bool pauseActiv;

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
        AddScore(0);
        restart.text = "Ваш счет: " + score + "\n Нажмите R для restart ";
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
            pause.gameObject.SetActive(pauseActiv);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    void Restart()
    {
        score = 0;
        restart.gameObject.SetActive(false);
        health = 3;
        pauseActiv = false;
        ControlHeart();
        SceneManager.LoadScene(0);
    }

    public void ControlHeart()
    {
        for (int i = 0; i < heart.Length; i++)
        {
            if (i < health)
            {
                heart[i].gameObject.SetActive(true);
            }
            else
            {
                heart[i].gameObject.SetActive(false);
            }
        }
    }

    public void DeathСomes()
    {
        health--;
        ControlHeart();
        if (health == 0)
        {
            pauseActiv = true;
            restart.gameObject.SetActive(true);
        }
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        point.text = "POINTS: " + score;
    }


}
