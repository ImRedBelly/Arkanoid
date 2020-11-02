using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text point;
    public int sumPoint;

    void Update()
    {
        point.text = "POINTS: " + sumPoint;
    }
}
