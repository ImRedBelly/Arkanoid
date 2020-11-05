using UnityEngine;
public class Platform : MonoBehaviour
{
    public bool autoPlay;
    Ball ball;
    public float MaxX;
    void Start()
    {
        ball = FindObjectOfType<Ball>();   
    }
    void Update()
    {
        if (autoPlay)
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.x = Mathf.Clamp(mouseWorldPosition.x, -MaxX, MaxX);
            transform.position = new Vector2(mouseWorldPosition.x, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(ball.transform.position.x, transform.position.y);
        }
        
    }
}
