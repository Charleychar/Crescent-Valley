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
    public string textLines;
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
    }
}
