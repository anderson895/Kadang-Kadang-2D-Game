using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the score text component

    public void menuFunction()
    {
        SceneManager.LoadScene("menu");
    }

    public void lvl1Function()
    {
        ScoreScript.curscore = 0; // Reset the score to 0
        SceneManager.LoadScene("level1");
    }

    public void loadingFunction()
    {
        SceneManager.LoadScene("loading");
    }

    public void leaderboardFunction()
    {
        SceneManager.LoadScene("leaderboard");
    }
    public void creditFunction()
    {
        SceneManager.LoadScene("credit");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
