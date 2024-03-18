using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] VideoPlayer cutscene;
    [SerializeField] VideoClip cutscene3;
    [SerializeField] BoxCollider2D idaSceneCollider;
    [SerializeField] JournalMechanicIntro journalIntro;
    [SerializeField] Image flowerDrawing;
    private bool ImportantCutscenesPlayed;
    
    
    // Start is called before the first frame update
    void Start()
    {
        flowerDrawing.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
    }
}
