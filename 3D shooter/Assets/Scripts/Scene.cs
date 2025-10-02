using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowInstructions()
    {
        SceneManager.LoadScene("3 - Instructions");
    }

    public void HideInstructions()
    {
        SceneManager.LoadScene("1 - Main Menu"); 
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("1 - Main Menu");
    }

    public void BackToGame()
    {
        SceneManager.LoadScene("Demo");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}