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
                pause.gameObject.SetActive(false);
                Time.timeScale = 1f;
                pauseActiv = false;
            }
            else
            {
                pause.gameObject.SetActive(true);
                Time.timeScale = 0f;
                pauseActiv = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.R)) //Перезагрузка уровня
        {
            score = 0; // обновляю счет
            SceneManager.LoadScene(0);  //при resrtart возвращаю в начало игры
            restart.gameObject.SetActive(false); //скрываю конечный экран
            health = 3;     //возвращаю жизни
            pauseActiv = false;     //снимаю паузу с платформы
            for (int i = 0; i < heart.Length; i++)
            {
                heart[i].gameObject.SetActive(true); 
            }
        }
    }
    public void AddScore(int addScore) 
    {
        score += addScore;
        point.text = "POINTS: " + score;
    }
    public void DeathСomes()
    {
        health--;
        heart[health].gameObject.SetActive(false); //убираю сердечки
        if (health == 0)
        {
            pauseActiv = true; //Чтобы платформа не двигалась во время проигрыша:)
            restart.gameObject.SetActive(true);
        }
    }
}
