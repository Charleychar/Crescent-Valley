using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCutscene : MonoBehaviour
{
    [SerializeField] BoxCollider2D idaFlowerCollider;
    private CutsceneTrigger cutsceneTrigger;
    private BoxCollider2D MyCollider;
    private string PlayerTag;
    private void Start()
    {
        cutsceneTrigger = GetComponent<CutsceneTrigger>();
        MyCollider = GetComponent<BoxCollider2D>();
        PlayerTag = "Player";
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerTag))
        {
            PlayCutscene();
        }
    }
    private void PlayCutscene()
    {
        if (idaFlowerCollider.enabled == true && this.gameObject.name == "Dining hall")
        {
            return;
        }
        else if (idaFlowerCollider.enabled == true && this.gameObject.name == "Dining hall 2")
        {
            return;
        }
        else
        {
            MyCollider.enabled = false;
            cutsceneTrigger.TriggerCutscene();
        }    
      
    }
}
