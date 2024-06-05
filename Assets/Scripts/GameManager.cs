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
    public TextMeshProUGUI Tutorial;
    public AudioSource backgroundMusic;

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

    public static int powerUpsHit = 0;
    public int livesRemaining = 3;
    public int currentLevel = 1;
    public int scoreAdd = 1;
    public float timeBetweenLevels;
    public float delay = 10f;
    private int numberOfLevels = 4;

    // Variables for managing level increases
    // public int obstacleCountIncrease = 2;
    public float speedMultiplier = 3f;
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
        //RestartGame();
        SetCountScoreText();
        SetCountLivesText();
        StartCoroutine(LevelIncreaseRoutine());
        StartCoroutine(SetTutorialText());
    }

    IEnumerator LevelIncreaseRoutine()
    {
        // This function should run 2 times so there should be 2 level increases for a total of 3 levels
        yield return new WaitForSeconds(30f);
        Debug.Log("tutorial ends here");
        int i = 1;
        while (i < numberOfLevels)
        {
            yield return new WaitForSeconds(timeBetweenLevels);
            LevelIncrease();
            i++;
        }
        SetEndText();
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

    void SetEndText()
    {
        countLevelText.text = "All Levels Completed You Win!";
    }

    IEnumerator SetTutorialText()
    {
        Tutorial.text = "Press A, W, and D or arrow keys to move and jump";
        yield return new WaitForSeconds(6f);
        Tutorial.text = "Press Shift to move faster from left to right";
        yield return new WaitForSeconds(6f);
        Tutorial.text = "Collect Cheese, Redbull Cans, and Carrots to collect points";
        yield return new WaitForSeconds(6f);
        Tutorial.text = "Avoid Logs, Rocks, Rolling Boulders, and other Hamsters or else you'll lose lives";
        yield return new WaitForSeconds(6f);
        Tutorial.text = "Get to the end of 3 levels to win the Game";
        yield return new WaitForSeconds(6f);
        Tutorial.text = "Good Luck!";
        yield return new WaitForSeconds(5f);
        Tutorial.text = " ";
    }  

    void EndGame()
    {
        Time.timeScale = 0; // Pause the game
        Debug.Log("You died!");
        SceneManager.LoadScene("GameOverScene");
    }

    void RestartGame()
    {
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    void LevelIncrease()
    {
        currentLevel++;
        scoreAdd = (int)(scoreAdd * speedMultiplier);
        SetCountLevelText();

        // Debug.Log("Level increased to " + currentLevel + ", speed multiplier is " + speedMultiplier);

        IncreaseObstacleCount();
        IncreaseWheelSpeed();

        // Increase the pitch of the background music
        if (backgroundMusic != null)
        {
            backgroundMusic.pitch += 0.3f;
        }
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

    //void DecreaseCollectibleDeletionTime()
    //{
    //    ObstacleGenerator generator = FindObjectOfType<ObstacleGenerator>();
    //    if (generator != null)
    //    {
    //        generator.collectibleLifetime /= speedMultiplier;
    //        Debug.Log("Deletion time: " + generator.collectibleLifetime);
    //    }
    //}
}
