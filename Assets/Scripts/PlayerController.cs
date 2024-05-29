using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    private CollisionTrigger collision;

    private float movementX;
    private bool isGrounded = false;
    private bool isDashing = false; // make function

    public float move_speed;
    public float jumping_speed;
    public float dash_speed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>(); 
        animator = GetComponent<Animator>();
        collision = GetComponent<CollisionTrigger>();
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
                isDashing = true;
            }
            else
            {
                isDashing = false;
            }

        }
    }

    void OnJump()
    {
        if (collision.Grounded())
        {
            collision.isGrounded = false; // Set grounded flag to false, jumping so no longer on the ground
            rb.AddForce(Vector3.up * jumping_speed, ForceMode.VelocityChange);
            animator.SetBool("isJumping", true);
        }
    }

    public bool publicDash()
    {
        return isDashing;
    }

    private void FixedUpdate() 
    {
        //Vector3 left_right_movement = new Vector3 (movementX, 0.0f, 0.0f);
        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        Vector3 left_right_movement = new Vector3 (movementX, 0.0f, 0.0f);

        if (movementX != 0){
            animator.SetBool("isStrafing", true);
            animator.SetBool("isIdle", false);
        }
        else{
            animator.SetBool("isStrafing", false);
            animator.SetBool("isIdle", true);
        }

        if (isDashing){
            rb.MovePosition(transform.position + left_right_movement * Time.deltaTime * dash_speed);
        }
        else{
            rb.MovePosition(transform.position + left_right_movement * Time.deltaTime * move_speed);
        }

        float added_gravity = 5.0f;
        rb.AddForce(Vector3.down * added_gravity);
    }

}