using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

// Game manager is a singleton class: only one instance across the game

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public TextMeshProUGUI countScoreText;
    public TextMeshProUGUI countLivesText;


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
        SetCountScoreText();
        SetCountLivesText();

        // restartButton.SetActive(false);
    }

    public int powerUpsHit = 0;
    public int livesRemaining = 3;

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

    public void HandlePowerUpCollision()
    {
        powerUpsHit++;
        SetCountScoreText();
        Debug.Log("Power-up hit! Total power-ups hit: " + powerUpsHit++);

        if (powerUpsHit == 3)
        {
            // EndGame();
            Debug.Log("Next level starts");

            LevelIncrease();
    
        }
    }

    // this is the same thing and handleobstacle collision, but it takes away from the score for bad objects
    public void HandleObstacleCollision()
    {
        // SetCountText();
        livesRemaining--;
        SetCountLivesText();

        if (livesRemaining == 0)
        {
            EndGame();

        }
    }

    void SetCountScoreText()
    {
        countScoreText.text = "Score: " + powerUpsHit.ToString();
    }

    void SetCountLivesText()
    {
        countLivesText.text = "Lives: " + livesRemaining.ToString();
    }

    void EndGame()
    {
        Time.timeScale = 0; // Pause the game
        // restartButton.SetActive(true); // Show the restart button
        Debug.Log("You died!");
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game

        // Credit: https://discussions.unity.com/t/how-can-i-end-and-reset-the-game-when-ball-collides-with-wallleft/170882/2 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Pauses screen
    }

    // Triggers necessary level increase operations:
    // Increase in obstacle count, wheel speed increase, collectible deletion time decreases
    // Make music speed up with the wheel
    
    void LevelIncrease()
    {
        countScoreText.text = "Level Completed!";
    }

}


