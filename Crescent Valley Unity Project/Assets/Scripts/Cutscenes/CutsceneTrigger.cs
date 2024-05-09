using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CutsceneTrigger : MonoBehaviour
{
    private CutsceneManager cutsceneManager;
    [SerializeField] int FirstSlide;
    [SerializeField] int LastSlide;

    private DialoguePortraits portraitManager;
    [SerializeField] int firstPortrait;
    [SerializeField] int lastPortrait;

    private GameObject portraitObject;

    private void Start()
    {
        cutsceneManager = FindObjectOfType<CutsceneManager>();
        portraitManager = FindObjectOfType<DialoguePortraits>();
        portraitObject = GameObject.Find("Portrait");
    }
    
    public void TriggerCutscene()
    {
        cutsceneManager.ActivateCutscene(FirstSlide, LastSlide);
        
    }

    public void TriggerPortraits()
    {
        portraitManager.ShowPortrait(firstPortrait, lastPortrait);
        //portraitObject.SetActive(true);
    }
}
