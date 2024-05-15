using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;

    private float movementX;
    //private bool isJumping = false;
    private bool isDashing = false;

    public float move_speed;
    public float jumping_speed;
    public float dash_speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>(); 
        animator = GetComponent<Animator>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;   

        // Check if shift is pressed
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            // Check if moving to the left ("A" key) or right ("D" key) while dashing
            if ((movementX < 0 && Keyboard.current.aKey.isPressed) || (movementX > 0 && Keyboard.current.dKey.isPressed))
            {
                //StartCoroutine(Dash());
                isDashing = true;
            }
            else
            {
                isDashing = false;
            }

        }
    }

    /*void OnJump()
    {
        if (!isJumping)
        {
            animator.SetTrigger("Jump");
            isJumping = true; // Set jumping flag to true
            rb.AddForce(Vector3.up * jumping_speed, ForceMode.VelocityChange);
        }
    }*/

    private void FixedUpdate() 
    {
        //Vector3 left_right_movement = new Vector3 (movementX, 0.0f, 0.0f);
        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        //rb.MovePosition(transform.position + left_right_movement * Time.deltaTime * move_speed);
        Vector3 left_right_movement = new Vector3 (movementX, 0.0f, 0.0f);
        if (isDashing)
        {
            rb.MovePosition(transform.position + left_right_movement * Time.deltaTime * dash_speed);
        }
        else
        {
            rb.MovePosition(transform.position + left_right_movement * Time.deltaTime * move_speed);
        }
    }

}