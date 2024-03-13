using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalMechanicIntro : MonoBehaviour
{
    [SerializeField] Canvas journalTutorialCanvas;
    [SerializeField] string PlayerTag;
    
    
    // Start is called before the first frame update
    void Start()
    {
        journalTutorialCanvas.enabled = false;
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
    }
}
