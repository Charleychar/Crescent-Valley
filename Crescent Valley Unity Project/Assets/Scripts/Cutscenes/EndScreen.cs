using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    [SerializeField] BoxCollider2D finalScene;
    [SerializeField] BoxCollider2D alexScene;
    [SerializeField] Canvas endScreen;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName != "End Screen")
        {
            endScreen.enabled = false;
        }
        
    }

    public void ShowEndScreen()
    {
        print("hello");
        
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (finalScene.enabled == false && alexScene.enabled == false && sceneName == "Chapter 2")
        {
            SceneManager.LoadScene("End Screen");
        }
        else if (sceneName == "Main Game")
        {
            return;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
