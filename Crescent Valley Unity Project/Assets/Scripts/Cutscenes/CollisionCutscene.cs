using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionCutscene : MonoBehaviour
{
    [SerializeField] BoxCollider2D idaFlowerCollider;
    [SerializeField] Image flowerEntry;
    private CutsceneTrigger cutsceneTrigger;
    private BoxCollider2D MyCollider;
    private string PlayerTag;
    
    private void Start()
    {
        cutsceneTrigger = GetComponent<CutsceneTrigger>();
        MyCollider = GetComponent<BoxCollider2D>();
        PlayerTag = "Player";
        flowerEntry.enabled = false;
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

        AddEntry(); 
    }

    public void AddEntry()
    {
        if (flowerEntry.enabled == false)
        {
            flowerEntry.enabled = true;
        }
        else
        {
            return;
        }
    }
}
