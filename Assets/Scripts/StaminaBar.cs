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
    public float jumpDValue;
    private bool isEmpty = false;

    private bool canRegenerate = true; // New flag for regeneration
    public float emptyDelay; // Time to wait before regenerating

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
        if (stamina > minStamina)
        {
            isEmpty = false;
            if (controller.publicDash())
                DecreaseEnergy();
            else if (controller.publicJump())
                JumpDecreaseEnergy();
            else if (stamina < maxStamina && canRegenerate)
                IncreaseEnergy();
        }
        else
        {
            if (!isEmpty)
            {
                isEmpty = true;
                StartCoroutine(WaitBeforeRegenerate());
            }
        }

        staminaBar.value = stamina;
    }

    private void DecreaseEnergy()
    {
        stamina -= dValue * Time.deltaTime;
    }

    private void JumpDecreaseEnergy()
    {
        stamina -= jumpDValue;
    }

    private void IncreaseEnergy()
    {
        stamina += dValue * Time.deltaTime;
    }

    private IEnumerator WaitBeforeRegenerate()
    {
        canRegenerate = false; // Prevent regeneration
        yield return new WaitForSeconds(emptyDelay); // Wait for specified seconds
        canRegenerate = true; // Allow regeneration
        stamina += 5;
    }

    public bool EmptyStamina()
    {
        return isEmpty;
    }
}


