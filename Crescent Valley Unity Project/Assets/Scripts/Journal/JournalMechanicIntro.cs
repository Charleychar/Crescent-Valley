using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class JournalMechanicIntro : MonoBehaviour
{
    [SerializeField] Canvas journalTutorialCanvas;
    [SerializeField] Canvas journalUI;
    [SerializeField] string PlayerTag;
    [SerializeField] TextMeshProUGUI line1;
    [SerializeField] TextMeshProUGUI line2;
    [SerializeField] Cutscenes cutscenePlayer;
    [SerializeField] VideoClip idaFlower2;
    //[SerializeField] GameObject player;

    GameObject journal;
    GameObject player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        journalTutorialCanvas.enabled = false;
        journal = GameObject.Find("Journal Canvas");
        player = GameObject.Find("Player");
        line2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && line2.enabled == false && journalTutorialCanvas == true)
        {
            line1.enabled = false;
            line2.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && line2.enabled == true)
        {
            print("end of tutorial");
            journalTutorialCanvas.enabled = false;
            journalUI.enabled = false;
            cutscenePlayer.PlayCutscene(idaFlower2);
            line2.enabled = false;
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        //journalTutorialCanvas.enabled = true;
        //StartJournalTutorial();
        
        //if (collision.CompareTag(PlayerTag))
        //{
        //    journalTutorialCanvas.enabled = true;
        //}
    }

    public void StartJournalTutorial()
    {
        print("tutorial");
        journalTutorialCanvas.enabled = true;
        journalUI.enabled = true;
        journal.GetComponent<Journal>().enabled = true;
        player.GetComponent<PlayerMovement>().DisableMovement();
        player.GetComponent<PlayerMovement>().enabled = false;

    }

    //public void TutorialText()
    //{
    //    line1.SetActive(false);
    //    line2.SetActive(true);
    //}
}
