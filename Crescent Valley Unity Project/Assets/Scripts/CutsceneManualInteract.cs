using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneManualInteract : MonoBehaviour
{

    //Cutscenes cutscenePlayScript;
    [SerializeField] VideoClip respectiveCutscene;
    [SerializeField] VideoPlayer cutscenePlayer;
    [SerializeField] BoxCollider2D benCollider;

    bool ben = false;
    GameObject player;
    PlayerMovement PM;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (cutscenePlayer.isPaused)
        {
            cutscenePlayer.Stop();
            cutscenePlayer.clip = null;
            player.GetComponent<PlayerMovement>().enabled = true;
            PM.EnableMovement();

        }

        if (Input.GetKeyDown(KeyCode.E) && ben == true)
        {
            PlayCutscene(respectiveCutscene);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ben = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ben = false;
    }

    public void PlayCutscene(VideoClip newClip)
    {
        cutscenePlayer.clip = newClip;
        cutscenePlayer.Play();
        benCollider.enabled = false;
        PM.DisableMovement();
        player.GetComponent<PlayerMovement>().enabled = false;
    }

    

}
