using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image[] heart;
    public Text pause;
    public Text restart;
    public Text point;
    public Text timer;

    public int score;
    public int health = 3;
    public float time;
    public bool pauseActiv;

    int timeInt;

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
        if (time > 0)
        {
            time -=  Time.deltaTime;
            timeInt = Mathf.RoundToInt(time);
            timer.text = timeInt.ToString();
            if(timeInt <= 0)
            {
                timer.text = "";
            }
        }
       


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
        for (int i = 0; i < health; i++)
        {
            heart[i].gameObject.SetActive(true);
        }
        SceneManager.LoadScene(0);
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        point.text = "POINTS: " + score;
    }
    public void DeathСomes()
    {
        health--;
        HeartMinus();

        if (health == 0)
        {
            pauseActiv = true;
            restart.gameObject.SetActive(true);
        }
    }
    public void HeartPlus()
    {
        for (int i = 0; i < health; i++)
        {
            heart[i].gameObject.SetActive(true);
        }
    }

    public void HeartMinus()
    {
        heart[health].gameObject.SetActive(false);
    }
}
