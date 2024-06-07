using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public void OpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OpenGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenAuth()
    {
        SceneManager.LoadScene("Auth");
    }

    public void OpenScores()
    {
        SceneManager.LoadScene("Scores");
    }
   
}
