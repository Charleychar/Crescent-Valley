using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class CutsceneManager : MonoBehaviour
{
    /*
    //[SerializeField] VideoPlayer cutscene;
    //[SerializeField] VideoClip cutscene3;
    [SerializeField] BoxCollider2D idaSceneCollider;
    [SerializeField] JournalMechanicIntro journalIntro;
    [SerializeField] Image flowerDrawing;
    private bool ImportantCutscenesPlayed;

    public bool HasCutscenePlayed()
    {
        if (ImportantCutscenesPlayed)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void CutscenePlayed(int CutsceneNo)
    {
        if (CutsceneNo == 3)
        {
            ImportantCutscenesPlayed = true;
            StartCoroutine("WaitForTutorial");
        }
        
        //if (CutsceneNo == 3 && cutscene.isPaused)
        //{
        //    journalIntro.StartJournalTutorial();
        //}
    }

    private IEnumerator WaitForTutorial()
    {
        yield return new WaitForSeconds(25.5f);
        flowerDrawing.enabled = true;
        journalIntro.StartJournalTutorial();
    }*/

    private IdaNoiseScene idaNoiseScene;

    [SerializeField] GameObject CutsceneObject;
    [SerializeField] PlayerMovement PM;
    [SerializeField] Image CurrentCutsceneSlide;
    [SerializeField] Sprite[] CutsceneSlides;   
    [SerializeField] string[] cutsceneSlideDialogue;  
    [SerializeField] TextMeshProUGUI cutsceneDialogue;
    [SerializeField] Image overlayComponent;
    [SerializeField] GameObject dialoguePortrait;

    [SerializeField] BoxCollider2D diningScene1;
    [SerializeField] BoxCollider2D diningScene2;

    [SerializeField] GameObject inventory;
    [SerializeField] GameObject journal;

    private CutsceneTrigger cutsceneTrigger;

    private bool CutsceneActive;
    private int CurrentCutsceneNo;
    private int LastQueuedCutsceneNo;

    //private DialoguePortraits portraitManager;

    [SerializeField] float textSpeed;

    [SerializeField] Canvas dialogueCanvas;
    [SerializeField] GameObject dialogueBox;

    private void Start()
    {
        idaNoiseScene = FindObjectOfType<IdaNoiseScene>();
        //portraitManager = FindObjectOfType<DialoguePortraits>();
        //dialoguePortrait.SetActive(false);
        cutsceneTrigger = FindObjectOfType<CutsceneTrigger>();
    }



    public void ActivateCutscene(int FirstCutsceneNo, int LastCutsceneNo)
    {
        CutsceneActive = true;
        CutsceneObject.SetActive(true);
        CurrentCutsceneNo = FirstCutsceneNo;
        CurrentCutsceneSlide.sprite = CutsceneSlides[FirstCutsceneNo];
        LastQueuedCutsceneNo = LastCutsceneNo;
        PM.DisableMovement();
        journal.SetActive(false);
        inventory.SetActive(false);
        dialoguePortrait.SetActive(true);

        if (cutsceneSlideDialogue[CurrentCutsceneNo] != "")
        {

            //Display Text
            cutsceneDialogue.text = string.Empty;
            dialogueCanvas.enabled = true;
            dialogueBox.SetActive(true);
            StartCoroutine("TypingEffect");

            //Display Portrait
            cutsceneTrigger.TriggerPortraits();
            //dialoguePortrait.SetActive(true);

        }
    }

    private void Update()
    {
        if (CutsceneActive && Input.GetKeyDown(KeyCode.Space))
        {
            if (CurrentCutsceneNo != LastQueuedCutsceneNo)
            {
                NextCutsceneSlide();
            }
            else
            {
                ExitCutscene();
            }
        }
    }

    private void NextCutsceneSlide()
    {
        cutsceneDialogue.text = string.Empty;
        dialogueBox.SetActive(false);
        dialogueCanvas.enabled = false;

        CurrentCutsceneNo++;
        CurrentCutsceneSlide.sprite = CutsceneSlides[CurrentCutsceneNo];

        if (cutsceneSlideDialogue[CurrentCutsceneNo] != "")
        {
            cutsceneDialogue.text = string.Empty;
            dialogueCanvas.enabled = true;
            dialogueBox.SetActive(true);
            StartCoroutine("TypingEffect");
        }
    }
    private void ExitCutscene()
    {
        StartCoroutine("FadeOut");  
        CutsceneActive = false;  
        CutsceneObject.SetActive(false);
        PM.EnableMovement();
        journal.SetActive(true);
        inventory.SetActive(true);
        //dialoguePortrait.SetActive(false);

        if (cutsceneSlideDialogue[CurrentCutsceneNo] != "")
        {
            cutsceneDialogue.text = string.Empty;
            dialogueBox.SetActive(false);
            //dialoguePortrait.SetActive(false);
            dialogueCanvas.enabled = false;
        }

    }

    private IEnumerator FadeOut()
    {
        for (float _alpha = overlayComponent.color.a; _alpha <= 1; _alpha += Time.deltaTime)
        {
            overlayComponent.color = new Color(overlayComponent.color.r, overlayComponent.color.g, overlayComponent.color.b, _alpha);
            yield return null;  
        }

        StartCoroutine("FadeIn");
    }

    private IEnumerator FadeIn()
    {
        for (float _alpha = overlayComponent.color.a; _alpha >= 0; _alpha -= Time.deltaTime)
        {
            overlayComponent.color = new Color(overlayComponent.color.r, overlayComponent.color.g, overlayComponent.color.b, _alpha);
            yield return null;
        }

        idaNoiseScene.StartIdaScene();
    }

    private IEnumerator TypingEffect()
    {
        foreach (char c in cutsceneSlideDialogue[CurrentCutsceneNo].ToCharArray())
        {
            cutsceneDialogue.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
