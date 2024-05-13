using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    private GameManager gameManager; // Reference to the GameManager instance
    //public WheelBehavior wheelBehavior;
    // public GameObject Environment;
    private Renderer screenRenderer;
    private Color originalColor;

    private void Start()
    {
        gameManager = GameManager.Instance; // Assign the GameManager instance to the reference

        screenRenderer = GetComponent<Renderer>(); // Get the renderer component of the screen
        originalColor = screenRenderer.material.color; // Store the original color
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision with obstacle!");
            //wheelBehavior.IncreaseSpeed(); 
            gameManager.HandleObstacleCollision();
            Destroy(other.gameObject); // Destroy the obstacle
        }

        if (other.gameObject.CompareTag("bad object"))
        {
            Debug.Log("Collision with obstacle!");
            //wheelBehavior.IncreaseSpeed(); 
            gameManager.BadObstacleCollision();
            StartCoroutine(FlashScreen()); // Start the screen flash
            Destroy(other.gameObject); // Destroy the obstacle
        }
    }

    private IEnumerator FlashScreen()
    {
        // Flash the screen red
        screenRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        // Return the screen to its original color
        screenRenderer.material.color = originalColor;
    }

}
