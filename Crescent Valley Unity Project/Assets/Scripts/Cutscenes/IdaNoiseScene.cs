using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdaNoiseScene : MonoBehaviour
{
    private CutsceneTrigger cutceneTrigger;

    [SerializeField] BoxCollider2D diningScene1;
    [SerializeField] BoxCollider2D diningScene2;
    [SerializeField] BoxCollider2D idaFlowerScene;

    void Start()
    {
        cutceneTrigger = GetComponent<CutsceneTrigger>();
    }

    
    void Update()
    {

    }

    public void StartScene()
    {
        cutceneTrigger.TriggerCutscene();
    }
}
