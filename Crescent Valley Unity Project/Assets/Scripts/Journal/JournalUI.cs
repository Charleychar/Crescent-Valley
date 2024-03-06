using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalUI : MonoBehaviour
{
    [SerializeField] Canvas journalUI;
    [SerializeField] Journal journalFunction;

    GameObject player;

    
    // Start is called before the first frame update
    void Start()
    {
        journalUI.enabled = false;
        player = GameObject.Find("Player");    
    }

    // Update is called once per frame
    void Update()
    {
        //close journal
        if (Input.GetKeyDown(KeyCode.F) && journalUI.enabled == true)
        {
            journalUI.enabled = false;
            journalFunction.enabled = false;
            player.GetComponent<PlayerMovement>().enabled = true;
        }            
    }   
}
