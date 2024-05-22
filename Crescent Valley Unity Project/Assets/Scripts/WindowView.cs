using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowView : MonoBehaviour
{
    [SerializeField] Canvas windowView;

    private PlayerMovement playerMovement;

    private bool closeToWindow = false;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }


    // Start is called before the first frame update
    void Start()
    {
        windowView.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && closeToWindow == true && windowView.enabled == false)
        {
            windowView.enabled = true;
            playerMovement.DisableMovement();
            playerMovement.enabled = false;
               
        }
        else if (Input.GetKeyDown(KeyCode.E) && windowView.enabled == true)
        {
            windowView.enabled = false;
            playerMovement.enabled = true;
            playerMovement.EnableMovement(gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        closeToWindow = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        closeToWindow = false;
    }
}
