using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Platform platform;
    public float speed;
    bool isStarted;

    void Update()
    {
        if (isStarted)
        {

        }
        else
        {
            Vector3 platformPosotion = platform.transform.position;
            Vector3 ballNewPosition = new Vector3(platformPosotion.x, platformPosotion.y + 0.65f, 0);
            transform.position = ballNewPosition;

            if (Input.GetMouseButtonDown(0))
                StartBall();
        }
    }
    void StartBall()
    {
        Vector2 force = new Vector2(1, 1);
        rb.AddForce(force * speed);
        isStarted = true;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
