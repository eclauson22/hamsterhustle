using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    private GameManager gameManager; // Reference to the GameManager instance
    //public WheelBehavior wheelBehavior;
    // public GameObject Environment;
    private void Start()
    {
        gameManager = GameManager.Instance; // Assign the GameManager instance to the reference
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
    }

}
