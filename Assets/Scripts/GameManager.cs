using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game manager is a singleton class: only one instance across the game

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject gameManagerObject = new GameObject("GameManager");
                instance = gameManagerObject.AddComponent<GameManager>();
                DontDestroyOnLoad(gameManagerObject);
            }
            return instance;
        }
    }

    public int obstaclesHit = 0; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void HandleObstacleCollision()
    {
        obstaclesHit++; 
        Debug.Log("Obstacle hit! Total obstacles hit: " + obstaclesHit);

        if (obstaclesHit == 3)
        {
            Debug.Log("All lives lost");
            // Add more here for what happens when all lives are lost
        }
    }
}


