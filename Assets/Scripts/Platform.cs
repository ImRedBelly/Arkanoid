using UnityEngine;

public class Platform : MonoBehaviour
{

    public ParticleSystem particlesMagnet;
    public bool autoPlay;
    public float MaxX;


    GameManager gameManager;
    Ball ball;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ball = FindObjectOfType<Ball>();
    }
    void Update()
    {
        MahnetTrue();

        if (!gameManager.pauseActiv)
        {
            if (autoPlay)
            {
                transform.position = new Vector2(ball.transform.position.x, transform.position.y);
            }
            else
            {


                Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPosition.x = Mathf.Clamp(mouseWorldPosition.x, -MaxX, MaxX);
                transform.position = new Vector2(mouseWorldPosition.x, transform.position.y);
            }
        }
    }

    public void MahnetTrue()
    {
        if (ball.isRevers)
        {
            particlesMagnet.gameObject.SetActive(true);  // если включен магнит, то включается партикл
        }
    }
}
