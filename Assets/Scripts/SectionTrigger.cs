using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    private GameManager gameManager; 
    private Renderer screenRenderer;
    private Color originalColor;

    // Assigned in unity editor
    public AudioSource obstacleAudioSource; 
    public AudioSource powerupAudioSource; 


    private void Start()
    {
        gameManager = GameManager.Instance; // Assign GameManager instance to the reference

        // For player red flash (Credit: Chat GPT)
        screenRenderer = GetComponent<Renderer>(); 
        originalColor = screenRenderer.material.color; // Store the original color

    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PowerUp"))
        {
            Debug.Log("Collision with power-up!");
            gameManager.HandlePowerUpCollision();
            powerupAudioSource.Play();
            Destroy(other.gameObject); // Destroy the obstacle
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision with obstacle!");
            gameManager.HandleObstacleCollision();
            obstacleAudioSource.Play();
            StartCoroutine(FlashScreen()); // Player flashes red
            Destroy(other.gameObject); // Destroy obstacle
        }
    }

    // Credit: Chat GPT
    private IEnumerator FlashScreen()
    {
        // Flash the character red (to use when player collides with obstacle)
        screenRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        // Return the screen to its original color
        screenRenderer.material.color = originalColor;
    }

}
