using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter2start : MonoBehaviour
{
    [SerializeField] CutsceneTrigger cutsceneTrigger;
    
    // Start is called before the first frame update
    void Start()
    {
        cutsceneTrigger = GetComponent<CutsceneTrigger>();
        cutsceneTrigger.TriggerCutscene();
        cutsceneTrigger.TriggerPortraits();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
