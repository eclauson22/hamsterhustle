using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    public float move_speed = 10.0f;
    public float jumping_height = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>(); 
    }

    private bool isGrounded;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wheel"))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;   
    }

    void OnJump()
    {
        //Jumping movement
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumping_height, ForceMode.Impulse); 
        }
    }

    private void FixedUpdate() 
    {
        Vector3 left_right_movement = new Vector3 (movementX, 0.0f, 0.0f);
        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        rb.MovePosition(transform.position + left_right_movement * Time.deltaTime * move_speed);
    }

}