using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutscene : MonoBehaviour
{
    private CutsceneTrigger cutsceneTrigger;
    
    void Start()
    {
        cutsceneTrigger = GetComponent<CutsceneTrigger>();
        cutsceneTrigger.TriggerCutscene();
        cutsceneTrigger.TriggerPortraits();
    }
}
