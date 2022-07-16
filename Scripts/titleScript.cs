using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titleScript : MonoBehaviour
{
    /// <summary>
    /// loads the first scene of the game
    /// </summary>
    public void startGame()
    {
        SceneManager.LoadScene("Level_00");
    }


    // Start is called before the first frame update
    void Start()
    {
        //sets up variables that can be used across scenes
        PlayerPrefs.SetInt("Current Level", 1);
        PlayerPrefs.SetInt("Total Score", 0);
        for(int i = 1; i < 10; i++)
        {
            PlayerPrefs.SetInt("level " + i + " shots", 0);
        }

    }

    public void exitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
