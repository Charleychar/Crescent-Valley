using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CornerIconVisible : MonoBehaviour
{
    [SerializeField] Canvas cornerIcon;
    [SerializeField] Canvas journal;
    [SerializeField] GameObject cutscenes;
    //[SerializeField] Canvas pauseMenu;
    //[SerializeField] Canvas cutsceneCanvas;
    //[SerializeField] Canvas fadeToBlack;
    //[SerializeField] Canvas dialogue;
    //[SerializeField] Canvas text;
    //[SerializeField] Canvas window;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (pauseMenu.enabled || cutsceneCanvas.enabled || fadeToBlack.enabled || dialogue.enabled || text.enabled || window.enabled)
        //{
        //    cornerIcon.enabled = false;
        //}
        //else
        //{
        //    cornerIcon.enabled = true;
        //}

        if (journal.enabled == true || cutscenes.activeInHierarchy == true)
        {
            cornerIcon.enabled = false;
        }
        else if (journal.enabled == false)
        {
            cornerIcon.enabled = true;
        }
    }
}
