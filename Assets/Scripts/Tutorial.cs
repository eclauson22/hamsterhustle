using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public GameObject SkipTutorialMenu; 
    public void SkipTutorial ()
    {
        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        Time.timeScale = 30f;
        Debug.Log("STARTING");
        yield return new WaitForSeconds(30f);
        Debug.Log("time waiting going back");
        Time.timeScale = 1f;
        SkipTutorialMenu.SetActive(false);
    }
}
