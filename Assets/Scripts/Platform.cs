using UnityEngine;

public class Platform : MonoBehaviour
{

    public ParticleSystem particlesMagnet;
    public bool autoPlay;
    public float MaxX;
    public float speed = 4;

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

        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    Keyboard(touch.position);
                    break;
                case TouchPhase.Stationary:
                    Keyboard(touch.position);
                    break;
            }
        }

        //if (!gameManager.pauseActiv)
        //{
        //    if (autoPlay)
        //    {
        //        transform.position = new Vector2(ball.transform.position.x, transform.position.y);
        //    }
        //    else
        //    {
        //        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //        mouseWorldPosition.x = Mathf.Clamp(mouseWorldPosition.x, -MaxX, MaxX);
        //        transform.position = new Vector2(mouseWorldPosition.x, transform.position.y);
        //    }
        //}
    }

    void Keyboard(Vector2 p)
    {
        if (p.x < Screen.width / 2)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    public void MahnetTrue()
    {
        if (ball.isRevers)
        {
            particlesMagnet.gameObject.SetActive(true);
        }
    }
}
