using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBehavior : MonoBehaviour
{
    public SectionTrigger sectionTrigger;
    public int RotationSpeed;
    public int count;
    //public int RotationSpeed = -10;
    // Start is called before the first frame update
    void Start()
    {
        RotationSpeed = -10;// = sectionTrigger.WheelSpeed;
    }  

    void Update()
    {  
        count += 1;
        if (count == 1000)
        {
            Debug.Log("count hit 1000, speed increased");
            RotationSpeed = RotationSpeed - 1;
            count = 0;
        }
        //RotationSpeed = sectionTrigger.WheelSpeed;
        //Debug.Log("Value from Script1: " + sectionTrigger.WheelSpeed);
       // RotationSpeed = sectionTrigger.WheelSpeed;
        transform.Rotate(0f, RotationSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
