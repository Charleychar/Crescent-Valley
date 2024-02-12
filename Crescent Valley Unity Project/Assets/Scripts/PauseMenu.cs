using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas pause;

    GameObject player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        pause.enabled = false;
        player = GameObject.Find("Player Sprite");
    }

    //opening and closing menu
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pause.enabled == false)
        {
            pause.enabled = true;
            player.GetComponent<PlayerMovement>().enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pause.enabled == true)
        {
            pause.enabled = false;
            player.GetComponent<PlayerMovement>().enabled = true;
        }        
    }

    public void Resume()
    {
        pause.enabled = false;
        player.GetComponent<PlayerMovement>().enabled = true;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


}