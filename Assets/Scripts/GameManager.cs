using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Game manager is a singleton class: only one instance across the game

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public TextMeshProUGUI countText;
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

    void Start()
    {
        SetCountText();
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
        SetCountText();
        Debug.Log("Obstacle hit! Total obstacles hit: " + obstaclesHit);

        if (obstaclesHit == 3)
        {
            EndGame();
            Debug.Log("All lives lost");
            // Add more here for what happens when all lives are lost
        }
    }

    //this is the same thing and handleobstacle collision, but it takes away from the score for bad objects
    public void BadObstacleCollision()
    {
        obstaclesHit--;
        SetCountText();
    }

    void SetCountText()
    {
        countText.text = "Score: " + obstaclesHit.ToString();
    }

    void EndGame()
    {
        countText.text = "Level Completed!";
    }

}


