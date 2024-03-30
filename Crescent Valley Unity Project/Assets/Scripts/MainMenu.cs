using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField] Canvas mainMenu;
    [SerializeField] Canvas controls;


    private void Start()
    {
        controls.enabled = false;
    }


    public void StartGame()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Controls()
    {
        mainMenu.enabled = false;
        controls.enabled = true;
    }

    public void BackToMenu()
    {
        controls.enabled = false;
        mainMenu.enabled = true;
    }
}
