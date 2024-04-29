using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject Environment;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Debug.Log("hit ending trigger");
            Instantiate(Environment, new Vector3(-3, 2, 10), Quaternion.identity);
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision");
            // Destroy(other.gameObject); // Destroy the obstacle
            GameManager.obstaclesHit++; // Increment the count of obstacles hit
        }
    }
}
