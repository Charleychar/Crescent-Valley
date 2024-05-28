using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JournalUI : MonoBehaviour
{
    [SerializeField] Canvas journalUI;
    [SerializeField] Journal journalFunction;
    
    public AudioSource audioSource;
    public AudioClip gettingJournalOut;
    public AudioClip puttingJournalAway;
    public float volume = 0.5f;

    GameObject player;

    
    // Start is called before the first frame update
    void Start()
    {
        journalUI.enabled = false;
        player = GameObject.Find("Player");    
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        //open/close journal 
        if (Input.GetKeyDown(KeyCode.Tab) && journalUI.enabled == false && sceneName == "Main Game")
        {
            journalUI.enabled = true;
            journalFunction.enabled = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            audioSource.PlayOneShot(gettingJournalOut, volume);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && journalUI.enabled == true && sceneName == "Main Game")
        {
            journalUI.enabled = false;
            journalFunction.enabled = false;
            player.GetComponent<PlayerMovement>().enabled = true;
            audioSource.PlayOneShot(puttingJournalAway, volume);
        }
    }   
}
