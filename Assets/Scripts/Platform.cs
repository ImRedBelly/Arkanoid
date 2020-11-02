using UnityEngine;

public class Platform : MonoBehaviour
{
    void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

        mouseWorldPosition.x = mouseWorldPosition.x > 7.7f ? 7.7f : mouseWorldPosition.x;
        mouseWorldPosition.x = mouseWorldPosition.x < -7.7f ? -7.7f : mouseWorldPosition.x;
        
        transform.position = new Vector2(mouseWorldPosition.x, transform.position.y);
    }
}
