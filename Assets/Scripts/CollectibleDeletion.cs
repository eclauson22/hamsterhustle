using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleDeletion : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance; // Assign GameManager instance to the reference

    }


    // Is a Power up since only power ups use triggers
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PowerUp collison recognized");
        // Destroy(other.gameObject);

        if (other.gameObject.CompareTag("Cheese"))
        {
            Destroy(other.gameObject); // Destroy the obstacle
        }
        else if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject); // Destroy the obstacle
        }
    }

    // Not a power up since power ups do not use collisions
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Obstacle collison recognized");
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(collision.gameObject); // Destroy obstacle
        }
    }


}
