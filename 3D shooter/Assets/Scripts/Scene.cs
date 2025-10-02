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
        SceneManager.LoadScene("Demo"); 
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Demo");
    }

    public void BackToGame()
    {
        SceneManager.LoadScene("2 - Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}