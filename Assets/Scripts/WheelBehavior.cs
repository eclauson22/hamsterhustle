using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBehavior : MonoBehaviour
{
    public int RotationSpeed;
    public int count;

    void Start()
    {
        RotationSpeed = -15;
    }  

    void Update()
    {  
        count += 1;
        if (count == 500)
        {
            Debug.Log("count hit 500, speed increased");
            RotationSpeed = RotationSpeed - 1;
            count = 0;
        }

        transform.Rotate(0f, RotationSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
