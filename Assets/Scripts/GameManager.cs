using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public TextMeshProUGUI countScoreText;
    public TextMeshProUGUI countLivesText;
    public TextMeshProUGUI countLevelText;

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

    public int powerUpsHit = 0;
    public int livesRemaining = 3;
    public int currentLevel = 1;
    public int scoreAdd = 1;
    public float timeBetweenLevels = 30f;

    // Variables for managing level increases
    // public int obstacleCountIncrease = 2;
    public float speedMultiplier = 2f;
    // public float collectibleDeletionTimeDecrease = 2f;

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

    void Start()
    {
        SetCountScoreText();
        SetCountLivesText();
        StartCoroutine(LevelIncreaseRoutine());
    }

    IEnumerator LevelIncreaseRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenLevels);
            LevelIncrease();
        }
    }

    public void HandlePowerUpCollision()
    {
        powerUpsHit += scoreAdd;
        SetCountScoreText();
        Debug.Log("Power-up hit! Total power-ups hit: " + powerUpsHit);
    }

    public void HandleObstacleCollision()
    {
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

    void SetCountLevelText()
    {
        countLevelText.text = "Level " + currentLevel.ToString();
    }



    void EndGame()
    {
        Time.timeScale = 0; // Pause the game
        Debug.Log("You died!");
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    void LevelIncrease()
    {
        currentLevel++;
        scoreAdd = (int)(scoreAdd * speedMultiplier);
        // TODO: make new text box for level count
        // countScoreText.text = "Level " + currentLevel + " Completed!";
        // countLevelText.text = "Level " + currentLevel + " Completed!";
        SetCountLevelText();

        // Debug.Log("Level increased to " + currentLevel + ", speed multiplier is " + speedMultiplier);

        IncreaseObstacleCount();
        IncreaseWheelSpeed();
        DecreaseCollectibleDeletionTime();
    }

    void IncreaseObstacleCount()
    {
        ObstacleGenerator generator = FindObjectOfType<ObstacleGenerator>();
        if (generator != null)
        {
            generator.spawnInterval /= (speedMultiplier * 4);
            Debug.Log("Obstacle generation interval: " + generator.spawnInterval);

        }
    }

    void IncreaseWheelSpeed()
    {
        WheelBehavior wheel = FindObjectOfType<WheelBehavior>();
        if (wheel != null)
        {
            wheel.RotationSpeed *= speedMultiplier;

            Debug.Log("Rotation speed: " + wheel.RotationSpeed);
        }
    }

    void DecreaseCollectibleDeletionTime()
    {
        ObstacleGenerator generator = FindObjectOfType<ObstacleGenerator>();
        if (generator != null)
        {
            generator.collectibleLifetime /= speedMultiplier;
            Debug.Log("Deletion time: " + generator.collectibleLifetime);
        }
    }
}
