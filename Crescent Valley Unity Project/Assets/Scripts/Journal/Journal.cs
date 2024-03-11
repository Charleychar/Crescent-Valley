using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    [SerializeField] int currentPage = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Journal>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {      
        SetPageActive();
        SwitchPages();
    }

    private void OnEnable()
    {
        //this.gameObject.GetComponent<Journal>().enabled = true;
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