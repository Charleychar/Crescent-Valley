using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalInterface : MonoBehaviour
{
    [SerializeField] Canvas journalUI;
    [SerializeField] int currentPage = 0;

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
        
        SetPageActive();
        SwitchPages();
    }

    private void SwitchPages()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentPage >= 5)
            {
                currentPage = 0;
            }
            else
            {
                currentPage++;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentPage <= 0)
            {
                currentPage = 5;
            }
            else
            {
                currentPage--;
            }
        }
    }

    private void SetPageActive()
    {
        int pageIndex = 0;
        
        foreach(Transform page in transform)
        {
            if (pageIndex == currentPage)
            {
                page.gameObject.SetActive(true);
            }
            else if (pageIndex != currentPage)
            {
                page.gameObject.SetActive(false);
            }
            pageIndex++;
        }
    }
}
