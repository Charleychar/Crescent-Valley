using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCutscene : MonoBehaviour
{
    private CutsceneTrigger MyTrigger;
    private BoxCollider2D MyCollider;
    private string PlayerTag;
    private void Start()
    {
        MyTrigger = GetComponent<CutsceneTrigger>();
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
        MyCollider.enabled = false;
        MyTrigger.TriggerCutscene();
    }
}
