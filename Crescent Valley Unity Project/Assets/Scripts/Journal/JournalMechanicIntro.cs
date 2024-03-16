using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalMechanicIntro : MonoBehaviour
{
    [SerializeField] Canvas journalTutorialCanvas;
    [SerializeField] Canvas journalUI;
    [SerializeField] string PlayerTag;
    [SerializeField] GameObject line1;
    [SerializeField] GameObject line2;
    //[SerializeField] GameObject player;

    GameObject journal;
    GameObject player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        journalTutorialCanvas.enabled = false;
        journal = GameObject.Find("Journal Canvas");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
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
        //player.GetComponent<PlayerMovement>().DisableMovement();
        //player.GetComponent<PlayerMovement>().enabled = false;

    }

    public void TutorialText()
    {
        line1.SetActive(false);
        line2.SetActive(true);
    }
}
