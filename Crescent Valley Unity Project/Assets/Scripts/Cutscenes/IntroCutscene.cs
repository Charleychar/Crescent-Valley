using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutscene : MonoBehaviour
{
    private CutsceneTrigger cutceneTrigger;
    
    void Start()
    {
        cutceneTrigger = GetComponent<CutsceneTrigger>();
        cutceneTrigger.TriggerCutscene();
        cutceneTrigger.TriggerPortraits();
    }
}
