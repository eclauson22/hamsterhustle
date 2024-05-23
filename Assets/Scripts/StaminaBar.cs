using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StaminaBar : MonoBehaviour
{
    public float stamina;
    float maxStamina;
    float minStamina;

    public Slider staminaBar;
    public float dValue;

    //PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        maxStamina = stamina;
        minStamina = 0;
        staminaBar.maxValue = maxStamina;
        staminaBar.minValue = minStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            DecreaseEnergy();
        else if (stamina != maxStamina)
            IncreaseEnergy();

        staminaBar.value = stamina;
    }

    private void DecreaseEnergy()
    {
        if(stamina > 0){
            stamina -= dValue * Time.deltaTime;
        }
    }

    private void IncreaseEnergy()
    {
        stamina += dValue * Time.deltaTime;
    }
}


