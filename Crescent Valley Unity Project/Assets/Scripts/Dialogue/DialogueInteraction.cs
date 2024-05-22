using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueInteraction : MonoBehaviour
{
    [SerializeField] int firstPortrait;
    [SerializeField] int lastPortrait;

    private DialoguePortraits portraitManager;
    private TypingSounds typingSounds;
    
    
    [SerializeField] Canvas dialogueCanvas;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject dialoguePortrait;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Canvas cutsceneCanvas;
    public TextMeshProUGUI dialogueText;
    public string[] dialogueLines;
    public float textSpeed;

    private int index;


    bool canInteract = false;
    bool textActive = false;

    // Start is called before the first frame update
    void Start()
    {
        dialogueCanvas.enabled = false;
        dialogueBox.SetActive(false);
        //dialoguePortrait.SetActive(false);
        dialogueText.text = string.Empty;
        portraitManager = FindObjectOfType<DialoguePortraits>();
        typingSounds = FindObjectOfType<TypingSounds>();
        //StartDialogue();
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract == true && textActive == false)
        {
            textActive = true;
            dialogueCanvas.enabled = true;
            dialogueBox.SetActive(true);

            StartDialogue();
            playerMovement.DisableMovement();
            playerMovement.enabled = false;
            //DisplayDialogue();
        }
        else if (Input.GetKeyDown(KeyCode.E) && textActive == true)
        {
            return;
        }

        //DisplayDialogue();

        if (Input.GetKeyDown(KeyCode.Space) && canInteract == true)
        {
            print(index + 1);
            if (dialogueLines.Length >= index + 1)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[index];                
                dialoguePortrait.SetActive(false);
                dialogueBox.SetActive(false);
                
                

            }
        }

        //attempt at bug fix
        /*if (canInteract == true)
        {
            playerMovement.DisableMovement();
        }
        else if (canInteract == false)
        {
            playerMovement.EnableMovement(gameObject.name);
        }*/

    }

    public void TriggerPortraits()
    {
        dialoguePortrait.SetActive(true);
        portraitManager.ShowPortrait(firstPortrait, lastPortrait);
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

        TriggerPortraits();

    }

    private IEnumerator TypingEffect()
    {
        foreach (char c in dialogueLines[index].ToCharArray())
        {
            dialogueText.text += c;
            typingSounds.PlayTypingSFX();
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        StopAllCoroutines();
        dialogueText.text = dialogueLines[index];
        if (index < dialogueLines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine("TypingEffect");
        }
        else
        {
            dialoguePortrait.SetActive(false);
            dialogueBox.SetActive(false);
            playerMovement.enabled = true;
            playerMovement.EnableMovement(gameObject.name);
            print("YIPEEEEE");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canInteract = true;

        /*if (cutsceneCanvas.enabled == true)
        {
            canInteract = true;

            print("can interact true");
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;

        /*if (cutsceneCanvas.enabled == false)
        {
            canInteract = false;

            
        }*/
    }

}
