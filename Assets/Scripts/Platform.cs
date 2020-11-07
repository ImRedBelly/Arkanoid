using UnityEngine;

public class Platform : MonoBehaviour
{
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
        if (gameManager.pauseActiv)
        {

        }
        else
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
}
