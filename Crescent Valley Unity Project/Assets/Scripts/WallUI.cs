using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallUI : MonoBehaviour
{
    [SerializeField] Canvas wallUI;
    [SerializeField] PlayerMovement playerMovement;

    bool wall = false;
    
    // Start is called before the first frame update
    void Start()
    {
        wallUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (wall == true && Input.GetKeyDown(KeyCode.E) && wallUI.enabled == false)
        {
            wallUI.enabled = true;
            playerMovement.DisableMovement();
        }
        else if (Input.GetKeyDown(KeyCode.E) && wallUI.enabled == true)
        {
            wallUI.enabled = false;
            playerMovement.EnableMovement();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        wall = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        wall = false;
    }
}
