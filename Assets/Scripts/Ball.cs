using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Platform platform;

    public int sumPoint;
    public float speed;
    bool isStarted;

    void Update()
    {
        if (isStarted)
        {
            if(transform.position.y < -5.3f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            } 
        }
        else
        {
            Vector2 platformPosotion = platform.transform.position;
            Vector2 ballNewPosition = new Vector2(platformPosotion.x, platformPosotion.y + 0.7f);
            transform.position = ballNewPosition;

            if (Input.GetMouseButtonDown(0))
                StartBall();
        }
    }
    void StartBall()
    {
        Vector2 force = new Vector2(Random.Range(-1.0f, 1.0f), 1);
        rb.AddForce(force * speed);
        isStarted = true;
    }
}
