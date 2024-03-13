using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] Cutscenes CutsceneObject;
    [SerializeField] VideoClip MyClip;
    [SerializeField] BoxCollider2D MyCollider;
    [SerializeField] string PlayerTag;
    [SerializeField] int CutsceneNo;

    [SerializeField] CutsceneManager cutsceneManager;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerTag))
        {
            if (CutsceneNo == 4)
            {
                if (cutsceneManager.HasCutscenePlayed())
                {
                    PlayCutscene();
                }
            }
            else
            {
                PlayCutscene();
            }
        }
    }

    private void PlayCutscene()
    {
        cutsceneManager.CutscenePlayed(CutsceneNo);
        CutsceneObject.PlayCutscene(MyClip);
        MyCollider.enabled = false;
    }
}
