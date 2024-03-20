using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CutsceneTrigger : MonoBehaviour
{
    [SerializeField] CutsceneManager cutsceneManager;
    [SerializeField] int FirstSlide;
    [SerializeField] int LastSlide;

    public void TriggerCutscene()
    {
        cutsceneManager.ActivateCutscene(FirstSlide, LastSlide);
    }
}
