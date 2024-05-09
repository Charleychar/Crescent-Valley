using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueCutscenes : MonoBehaviour
{
    [SerializeField] Canvas dialogueCanvas;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] Canvas cutsceneCanvas;
    [SerializeField] GameObject dialoguePortrait;
    //public TextMeshProUGUI dialogueText;
    //public string[] dialogueLines;
    //public float textSpeed;

    private int index;
    //private BoxCollider2D cutsceneCollider;

    private bool cutsceneTriggered = false;


    // Start is called before the first frame update
    void Start()
    {
        //cutsceneCollider = GetComponent<BoxCollider2D>();
        
        dialogueCanvas.enabled = false;
        dialogueBox.SetActive(false);
        dialoguePortrait.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (cutsceneCanvas.enabled == true)
        {
            cutsceneTriggered = true;
        }
        else if (cutsceneCanvas.enabled == false)
        {
            cutsceneTriggered = false;
        }

        /*if (Input.GetKeyDown(KeyCode.Space) && cutsceneCanvas == true)
        {
            if (dialogueText.text == dialogueLines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialoguePortrait.SetActive(false);
                dialogueText.text = dialogueLines[index];
            }
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (this.gameObject.name == "Ben at table")
        {
            return;
        }
        
        dialogueCanvas.enabled = true;
        //dialogueBox.SetActive(true);

        StartDialogue();

        //cutsceneCollider.enabled = false;
    }

    private void StartDialogue()
    {
        index = 0;
        //dialogueText.text = string.Empty;
        dialoguePortrait.SetActive(true);
        if (dialogueCanvas.enabled == true && dialogueBox.activeInHierarchy == true)
        {
            //StartCoroutine("TypingEffect");
        }

    }

    //private IEnumerator TypingEffect()
    //{
        
    //    foreach (char c in dialogueLines[index].ToCharArray())
    //    {
    //        dialogueText.text += c;
    //        yield return new WaitForSeconds(textSpeed);
    //    }
    //}

    private void NextLine()
    {
        /*print("hi");
        if (index < dialogueLines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine("TypingEffect");
        }
        else
        {
            dialogueBox.SetActive(false);
        }*/
    }
}
