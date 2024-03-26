using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneManualInteract : MonoBehaviour
{
    [SerializeField] BoxCollider2D diningScene1;
    [SerializeField] BoxCollider2D diningScene2;
    
    private CutsceneTrigger cutsceneTrigger;
    private BoxCollider2D MyCollider;
    private string PlayerTag;
    private bool PlayerNearby;


    // Start is called before the first frame update
    void Start()
    {
        cutsceneTrigger = GetComponent<CutsceneTrigger>();
        MyCollider = GetComponent<BoxCollider2D>();
        PlayerTag = "Player";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerNearby)
        {
            PlayCutscene();
        }
    }
    private void PlayCutscene()
    {
        if (diningScene1.enabled == true && diningScene2.enabled == true && this.gameObject.name == "Alex woken up")
        {
            return;
        }
        else
        {
            MyCollider.enabled = false;
            cutsceneTrigger.TriggerCutscene();
            PlayerNearby = false;
        }   
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
