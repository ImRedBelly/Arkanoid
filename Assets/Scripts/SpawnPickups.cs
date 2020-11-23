using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPickups : MonoBehaviour
{
    public GameObject[] pickups;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Instantiate(pickups[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(pickups[2]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Instantiate(pickups[3]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Instantiate(pickups[4]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Instantiate(pickups[5]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Instantiate(pickups[6]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Instantiate(pickups[7]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Instantiate(pickups[8]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Instantiate(pickups[9]);
        }

    }
}
