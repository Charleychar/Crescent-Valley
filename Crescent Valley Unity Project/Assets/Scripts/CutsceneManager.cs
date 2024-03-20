using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

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

    [SerializeField] GameObject CutsceneObject;
    [SerializeField] PlayerMovement PM;
    [SerializeField] Image CurrentCutsceneSlide;
    [SerializeField] Sprite[] CutsceneSlides;
    private bool CutsceneActive;
    private int CurrentCutsceneNo;
    private int LastQueuedCutsceneNo;

    public void ActivateCutscene(int FirstCutsceneNo, int LastCutsceneNo)
    {
        CutsceneActive = true;
        CutsceneObject.SetActive(true);
        CurrentCutsceneNo = FirstCutsceneNo;
        CurrentCutsceneSlide.sprite = CutsceneSlides[FirstCutsceneNo];
        LastQueuedCutsceneNo = LastCutsceneNo;
        PM.DisableMovement();
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
        CurrentCutsceneNo++;
        CurrentCutsceneSlide.sprite = CutsceneSlides[CurrentCutsceneNo];
    }
    private void ExitCutscene()
    {
        CutsceneActive = false;
        CutsceneObject.SetActive(false);
        PM.EnableMovement();
    }
}
