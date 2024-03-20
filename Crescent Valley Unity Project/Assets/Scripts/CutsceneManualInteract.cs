using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneManualInteract : MonoBehaviour
{
    private CutsceneTrigger MyTrigger;
    private BoxCollider2D MyCollider;
    private string PlayerTag;
    private bool PlayerNearby;


    // Start is called before the first frame update
    void Start()
    {
        MyTrigger = GetComponent<CutsceneTrigger>();
        MyCollider = GetComponent<BoxCollider2D>();
        PlayerTag = "Player";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayerNearby)
        {
            PlayCutscene();
        }
    }
    private void PlayCutscene()
    {
        MyCollider.enabled = false;
        MyTrigger.TriggerCutscene();
        PlayerNearby = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerTag))
        {
            PlayerNearby = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerTag))
        {
            PlayerNearby = false;
        }
    }
}
