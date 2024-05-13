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

    private TypingSounds typingSounds;

    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    private int index;

    bool canInteract = false;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        textCanvas.enabled = false;
        textBox.SetActive(false);
        text.text = string.Empty;
        typingSounds = FindObjectOfType<TypingSounds>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canInteract == true)
        {
            if (gameObject.CompareTag("locked door"))
            {
                audioSource.PlayOneShot(clip, volume);
            } 
            textCanvas.enabled = true;
            textBox.SetActive(true);

            StartDialogue();
            
            playerMovement.DisableMovement();
            playerMovement.enabled = false;
            //playerMovement.enabled = false;
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
                playerMovement.enabled = true;
                playerMovement.EnableMovement();
            }
        }
    }

    private IEnumerator TypingEffect()
    {
        foreach (char c in textLines[index].ToCharArray())
        {
            text.text += c;
            typingSounds.PlayTypingSFX();
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

    public void StartDialogue()
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
