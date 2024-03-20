using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCutscene : MonoBehaviour
{
    private CutsceneTrigger MyTrigger;
    void Start()
    {
        MyTrigger = GetComponent<CutsceneTrigger>();
        MyTrigger.TriggerCutscene();
    }
}
