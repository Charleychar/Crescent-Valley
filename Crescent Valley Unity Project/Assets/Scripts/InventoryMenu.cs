using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] Canvas inventory;
    [SerializeField] Canvas journalUI;

    GameObject player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        journalUI.enabled = false;
        inventory.enabled = false;
        player = GameObject.Find("Player Sprite");
    }

    //opening and closing menu
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && inventory.enabled == false)
        {
            inventory.enabled = true;
            player.GetComponent<PlayerMovement>().enabled = false;
        } 
        else if (Input.GetKeyDown(KeyCode.F) && inventory.enabled == true)
        {
            inventory.enabled = false;
            player.GetComponent<PlayerMovement>().enabled = true;
        }
    }
    
    public void OpenJournal()
    {
        journalUI.enabled = true;
        inventory.enabled = false;
    }
}
