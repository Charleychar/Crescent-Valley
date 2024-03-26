using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneAutomatic : MonoBehaviour
{
    [SerializeField] VideoPlayer cutscenePlayer;
    [SerializeField] VideoClip respectiveCutscene;

    GameObject player;
    PlayerMovement PM;
    
    
    // Start is called before the first frame update
    void Start()
    {
        PlayCutscene(respectiveCutscene);
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
    }

    public void PlayCutscene(VideoClip newClip)
    {
        cutscenePlayer.clip = newClip;
        cutscenePlayer.Play();
        PM.DisableMovement();
        player.GetComponent<PlayerMovement>().enabled = false;
    }
}
