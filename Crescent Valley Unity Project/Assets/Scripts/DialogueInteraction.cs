using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueInteraction : MonoBehaviour
{

    [SerializeField] Canvas dialogueCanvas;
    [SerializeField] GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    public float textSpeed;

    private int index;


    bool canInteract = false;

    // Start is called before the first frame update
    void Start()
    {
        dialogueCanvas.enabled = false;
        dialogueBox.SetActive(false);
        dialogueText.text = string.Empty;
        //StartDialogue();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract == true)
        {
            dialogueCanvas.enabled = true;
            dialogueBox.SetActive(true);

            StartDialogue();
            //DisplayDialogue();
        }

        //DisplayDialogue();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogueText.text == dialogueLines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[index];
            }
        }

    }

    /*private void DisplayDialogue()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogueText.text == dialogueLines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[index];
            }
        }
    }*/

    private void StartDialogue()
    {
        index = 0;
        dialogueText.text = string.Empty;
        if (dialogueCanvas.enabled == true && dialogueBox.activeInHierarchy == true)
        {
            StartCoroutine("TypingEffect");
        }
        
    }

    private IEnumerator TypingEffect()
    {
        foreach (char c in dialogueLines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < dialogueLines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine("TypingEffect");
        }
        else
        {
            dialogueBox.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        canInteract = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
    }

}
