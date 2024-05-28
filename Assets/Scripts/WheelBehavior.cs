using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBehavior : MonoBehaviour
{
    public float RotationSpeed;
    public int count;

    void Start()
    {
       //RotationSpeed = -20;// = sectionTrigger.WheelSpeed; //for old wheel 
        RotationSpeed = 15;
    }  

    void Update()
    {  

        //count += 1;
        //if (count == 500)
        //{
        //    Debug.Log("count hit 500, speed increased");
        //    RotationSpeed = RotationSpeed - 1;
        //    count = 0;
        //}
        // RotationSpeed = sectionTrigger.WheelSpeed;
        // Debug.Log("Value from Script1: " + sectionTrigger.WheelSpeed);
        // RotationSpeed = sectionTrigger.WheelSpeed;

        //transform.Rotate(0f, RotationSpeed * Time.deltaTime, 0f, Space.Self); //old wheel
        transform.Rotate(RotationSpeed * Time.deltaTime, 0f, 0f, Space.Self);
    }
}
