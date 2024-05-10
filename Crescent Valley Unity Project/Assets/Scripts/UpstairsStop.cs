using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpstairsStop : MonoBehaviour
{
    [SerializeField] Canvas textCanvas;
    [SerializeField] GameObject textBox;
    private FlavourText flavourText;
    [SerializeField] PlayerMovement playerMovement;

    bool inRange = false;
    
    // Start is called before the first frame update
    void Start()
    {
        flavourText = GetComponent<FlavourText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inRange == true)
        {
            playerMovement.enabled = true;
            playerMovement.EnableMovement();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inRange = true;

        textCanvas.enabled = true;
        textBox.SetActive(true);
        playerMovement.DisableMovement();
        playerMovement.enabled = false;
        print("bingus");
        flavourText.StartDialogue();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inRange = false;
    }
}
