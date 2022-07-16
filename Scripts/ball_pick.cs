using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ball_pick : MonoBehaviour
{
    public void pick_ball(string ballType)
    {
        PlayerPrefs.SetString("Ball Type", ballType);
        SceneManager.LoadScene("Level_01");
    }

    public void goBackHome()
    {
        SceneManager.LoadScene("Title");
    }
}
