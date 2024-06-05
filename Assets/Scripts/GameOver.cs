using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameOver : MonoBehaviour
{
    //public Copy gameManager;
    //public TextMeshProUGUI ScoreText;

    void Start()
    {
        //gameManager = GameManager.Instance;
        //ScoreText.text = "SCORE:"; //+ gameManager.powerUpsHit.ToString();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}
