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

    public float move_speed;
    public float jumping_speed;

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
        rb.MovePosition(transform.position + left_right_movement * Time.deltaTime * move_speed);
    }

}