using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image[] heart;
    public Text pause;
    public Text point;

    public static string keyBestScore = "bestRecord";

    public int score;
    public int health = 3;
    public bool pauseActiv;

    [Header("Sounds")]
    public AudioClip soundPause;
    AudioManager audioManager;
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

        audioManager = FindObjectOfType<AudioManager>();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Pause()
    {
        if (pauseActiv)
        {
            audioManager.PlaySound(soundPause);
            Time.timeScale = 1f;
            pauseActiv = false;
        }
        else
        {
            audioManager.PlaySound(soundPause);
            Time.timeScale = 0f;
            pauseActiv = true;
        }
        pause.gameObject.SetActive(pauseActiv);
    }

    public void Restart()
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
        if (health <= 0)
        {
            pauseActiv = true;
            SceneManager.LoadScene(7);
        }
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        point.text = "POINTS: " + score;
        SaveBestScore(); //DELETE
    }
    public void SaveBestScore()
    {
        int oldBestScore = PlayerPrefs.GetInt("bestRecord");
        if(oldBestScore < score)
        {
            PlayerPrefs.SetInt("bestRecord", score);
        }
    }


}
