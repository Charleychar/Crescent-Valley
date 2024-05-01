using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlavourText : MonoBehaviour
{
    [SerializeField] Canvas textCanvas;
    [SerializeField] GameObject textBox;
    [SerializeField] PlayerMovement playerMovement;
    public TextMeshProUGUI text;
    public string[] textLines;
    public float textSpeed;

    private int index;

    bool canInteract = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        textCanvas.enabled = false;
        textBox.SetActive(false);
        text.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract == true)
        {
            textCanvas.enabled = true;
            textBox.SetActive(true);

            StartDialogue();
            playerMovement.DisableMovement();          
        }

        if (Input.GetKeyDown(KeyCode.Space) && canInteract == true)
        {
            if (text.text == textLines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = textLines[index];
                playerMovement.EnableMovement();
            }
        }
    }

    private IEnumerator TypingEffect()
    {
        foreach (char c in textLines[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        if (index < textLines.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine("TypingEffect");
        }
        else
        {
            textBox.SetActive(false);
        }
    }

    private void StartDialogue()
    {
        index = 0;
        text.text = string.Empty;
        if (textCanvas.enabled == true && textBox.activeInHierarchy == true)
        {
            StartCoroutine("TypingEffect");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canInteract = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canInteract = false;
    }
}