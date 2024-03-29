using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CutsceneTrigger : MonoBehaviour
{
    private CutsceneManager cutsceneManager;
    [SerializeField] int FirstSlide;
    [SerializeField] int LastSlide;

    private void Start()
    {
        cutsceneManager = FindObjectOfType<CutsceneManager>();
    }
    public void TriggerCutscene()
    {
        cutsceneManager.ActivateCutscene(FirstSlide, LastSlide);
    }
}