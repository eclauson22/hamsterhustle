using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int obstaclesHit = 0; // Static variable to track the count of obstacles hit

    void Update()
    {
        if (obstaclesHit == 3)
        {
            Debug.Log("All lives lost");
            // can add more logic here
        }
    }
}

