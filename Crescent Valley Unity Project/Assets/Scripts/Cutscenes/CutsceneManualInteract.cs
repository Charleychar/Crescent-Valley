using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneManualInteract : MonoBehaviour
{
    [SerializeField] BoxCollider2D diningScene1;
    [SerializeField] BoxCollider2D diningScene2;
    [SerializeField] BoxCollider2D alexWokenScene;
    
    private CutsceneTrigger cutsceneTrigger;
    private BoxCollider2D MyCollider;
    private string PlayerTag;
    private bool PlayerNearby;

    CutsceneContainer cutsceneContainer;
    [SerializeField] int condition;
    [SerializeField] int effect;

    [SerializeField] bool noCondition = false;

    // Start is called before the first frame update
    void Start()
    {
        cutsceneTrigger = GetComponent<CutsceneTrigger>();
        cutsceneContainer = GetComponentInParent<CutsceneContainer>();
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
        if (cutsceneContainer.cutsceneTriggers[condition] || noCondition) //If my condition is met
        {
            MyCollider.enabled = false;
            cutsceneTrigger.TriggerCutscene();
            cutsceneTrigger.TriggerPortraits();
            PlayerNearby = false;
            cutsceneContainer.cutsceneTriggers[effect] = true;
        }

        /*if (diningScene1.enabled == true && diningScene2.enabled == true && this.gameObject.name == "Alex woken up")
        {
            return;
        }

        else
        {
            MyCollider.enabled = false;
            cutsceneTrigger.TriggerCutscene();
            PlayerNearby = false;
        } 
        
        if (alexWokenScene.enabled == false && this.gameObject.name == "Cupboard under the stairs")
        {
            MyCollider.enabled = false;
            cutsceneTrigger.TriggerCutscene();
            PlayerNearby = false;
        }
        else if (alexWokenScene.enabled == true && this.gameObject.name == "Cupboard under the stairs")
        {
            return;
        }*/


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
