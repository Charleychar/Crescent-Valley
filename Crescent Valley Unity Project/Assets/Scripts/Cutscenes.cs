using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Cutscenes : MonoBehaviour
{
    [SerializeField] VideoPlayer CutscenePlayer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CutscenePlayer.isPaused)
        {
            CutscenePlayer.Stop();
            CutscenePlayer.clip = null;
        }
        
    }

    public void PlayCutscene(VideoClip newClip)
    {
        CutscenePlayer.clip = newClip;
        CutscenePlayer.Play();
    }
}
