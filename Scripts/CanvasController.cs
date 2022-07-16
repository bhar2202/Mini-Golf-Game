using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CanvasController : MonoBehaviour
{
    int currentLevel;
    public GameObject gameplayPanel;
    public GameObject pausePanel;

    /// <summary>
    /// moves to the next scene/hole in the game
    /// </summary>
    public void goToNextScene()
    {
        PlayerPrefs.SetInt("Current Level", currentLevel + 1);
        SceneManager.LoadScene("Level_0" + PlayerPrefs.GetInt("Current Level"));
    }

    /// <summary>
    /// pauses the game
    /// </summary>
    public void pause()
    {
        Time.timeScale = 0;
        gameplayPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    /// <summary>
    /// resumes the game
    /// </summary>
    public void resume()
    {
        gameplayPanel.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    /// <summary>
    /// ends game and goes back to the homescreen
    /// </summary>
    public void goBackHome()
    {
        currentLevel = 1;
        SceneManager.LoadScene("Title");
    }

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        currentLevel = PlayerPrefs.GetInt("Current Level");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
