using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePortraits : MonoBehaviour
{
    [SerializeField] Image currentPortrait;
    [SerializeField] Sprite[] allPortraits;
    [SerializeField] Image dialogueBox;
    [SerializeField] Image portrait;

    private bool dialogueActive = false;
    
    private int currentPortraitSlide;
    private int lastQueuedPortraitSlide;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueActive == true && Input.GetKeyDown(KeyCode.Space))
        {
            if (currentPortraitSlide != lastQueuedPortraitSlide)
            {
                NextPortraitSlide();
            }
            else
            {
                ExitPortraits();
            }
        }

        if (dialogueBox.enabled == true)
        {
            portrait.enabled = true;
        }
        else if (dialogueBox.enabled == false)
        {
            portrait.enabled = false;
        }
    }

    public void ShowPortrait(int firstPortrait, int lastPortrait)
    {
        dialogueActive = true;
        currentPortraitSlide = firstPortrait;
        print(allPortraits[firstPortrait].name);
        portrait.sprite = allPortraits[firstPortrait];
        lastQueuedPortraitSlide = lastPortrait;
    }

    private void NextPortraitSlide()
    {
        currentPortraitSlide++;
        portrait.sprite = allPortraits[currentPortraitSlide];
        print(allPortraits[currentPortraitSlide].name);
    }

    private void ExitPortraits()
    {
        dialogueActive = false;
    }

   
}
