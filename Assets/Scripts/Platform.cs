using UnityEngine;

public class Platform : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        Vector3 mousePixelPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPosition);

        Vector3 padNewPosition = mouseWorldPosition;

        padNewPosition.z = 0;
        padNewPosition.y = -4.3f;

        transform.position = padNewPosition;
    }
}
