using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image[] heart;
    public Text pause;
    public Text point;


    public int score;
    public int health = 3;
    public bool pauseActiv;

    void Awake()
    {
       
        GameManager[] gameManagers = FindObjectsOfType<GameManager>();
        for (int i = 0; i < gameManagers.Length; i++)
        {
            if (gameManagers[i].gameObject != gameObject)
            {
                gameObject.SetActive(false);
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
        health = 3;
        pauseActiv = false;
        ControlHeart();
        AddScore(0);
        SceneManager.LoadScene(0);
        Destroy(gameObject);
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
            SceneManager.LoadScene(2);
            //restart.gameObject.SetActive(true);
            //restart.text = "Ваш счет: " + score + "\n Нажмите R для restart ";
        }
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        point.text = "POINTS: " + score;
    }


}
