using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalInterface : MonoBehaviour
{
    [SerializeField] Canvas journalUI;
    [SerializeField] WhichPage[] whichPage;

    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        journalUI.enabled = false;
        player = GameObject.Find("Player Sprite");
        
    }

    // Update is called once per frame
    void Update()
    {
        //close journal
        if (Input.GetKeyDown(KeyCode.F) && journalUI.enabled == true)
        {
            journalUI.enabled = false;
            player.GetComponent<PlayerMovement>().enabled = true;
        }
    }

    [System.Serializable]
    private class WhichPage
    {
        public Pages page;
    }



    
}
