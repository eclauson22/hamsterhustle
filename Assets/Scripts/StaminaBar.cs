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
    private PlayerController controller;

    public float dValue;

    //PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        maxStamina = stamina;
        minStamina = 0;
        staminaBar.maxValue = maxStamina;
        staminaBar.minValue = minStamina;
        controller = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.publicDash())
            DecreaseEnergy();
        else if (stamina < maxStamina)
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


