using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    private GameManager gameManager; 
    private Renderer screenRenderer;
    private Color originalColor;
    private Animator animator;
    private RainbowColors rainbowColors;

    // Assigned in unity editor
    public AudioSource obstacleAudioSource; 
    public AudioSource powerupAudioSource;
    public AudioSource cheeseAudioSource; 

    public bool isGrounded = false; 


    private void Start()
    {
        gameManager = GameManager.Instance; // Assign GameManager instance to the reference

        // For player red flash (Credit: Chat GPT)
        screenRenderer = GetComponent<Renderer>(); 
        originalColor = screenRenderer.material.color; // Store the original color
        rainbowColors = GetComponent<RainbowColors>();
        animator = GetComponent<Animator>();

    }

    public bool Grounded()
    {
        return isGrounded;
    }

    // Is a Power up since only power ups use triggers
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Cheese"))
        {
            Debug.Log("Collision with Cheese power-up!");
            gameManager.HandlePowerUpCollision();
            cheeseAudioSource.Play();
            rainbowColors.StartRainbowCycle();
            Destroy(other.gameObject); // Destroy the obstacle
        }
        else
        {
            Debug.Log("Collision with power-up!");
            gameManager.HandlePowerUpCollision();
            powerupAudioSource.Play();
            Destroy(other.gameObject); // Destroy the obstacle
        }
    }

    // Not a power up since power ups do not use collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }

        if (rainbowColors.isInvincible() == false && collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision with obstacle!");
            gameManager.HandleObstacleCollision();
            obstacleAudioSource.Play();
            StartCoroutine(FlashScreen()); // Player flashes red
            Destroy(collision.gameObject); // Destroy obstacle
        }
    }

    // Credit: Chat GPT
    private IEnumerator FlashScreen()
    {
        // Flash the character red (to use when player collides with obstacle)
        screenRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        // Return the screen to its original color
        screenRenderer.material.color = originalColor;
    }

}
