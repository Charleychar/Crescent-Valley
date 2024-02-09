using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    [SerializeField] Canvas inventory;

    GameObject player;
    
    
    // Start is called before the first frame update
    void Start()
    {
        inventory.enabled = false;
        player = GameObject.Find("Player Sprite");
    }

    //opening and closing menu
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {         
            OpenMenu();        
        }      
    }

    public void OpenMenu()
    {
        //print("menu");
        inventory.enabled = true;
        player.GetComponent<PlayerMovement>().enabled = false;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("close");
            CloseMenu();   
        }

    }

    public void CloseMenu()
    {
        inventory.enabled = false;
        player.GetComponent<PlayerMovement>().enabled = true;
    }

    
}
