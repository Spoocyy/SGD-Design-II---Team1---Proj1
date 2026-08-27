using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void CreditsMenu()
    {
        SceneManager.LoadSceneAsync("Credits");
    }

    public void BackMainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }



    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level 1");
    }

    public void HelpMenu()
    {
        SceneManager.LoadSceneAsync("Help");
    }
}
