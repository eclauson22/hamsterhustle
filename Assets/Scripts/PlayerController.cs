using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    public float move_speed;
    public float jumping_height;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>(); 
    }

    /*private bool isGrounded;

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
    }*/

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;   
    }

    //float velocity;
    void OnJump()
    {
        //velocity = Mathf.Sqrt(jumping_height * -2 * (Physics.gravity.y * gravityScale));
        rb.AddForce(Vector3.up * jumping_height, ForceMode.VelocityChange);
    }

    //float gravityScale = 5;
    private void FixedUpdate() 
    {
        Vector3 left_right_movement = new Vector3 (movementX, 0.0f, 0.0f);
        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        rb.MovePosition(transform.position + left_right_movement * Time.deltaTime * move_speed);
        //rb.AddForce(left_right_movement * move_speed);

        // Jumping without physics
        //velocity += Physics.gravity.y * gravityScale * Time.deltaTime;
        //transform.Translate(Vector3.up * velocity * Time.deltaTime);
    }

}