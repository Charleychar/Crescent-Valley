using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene6check : MonoBehaviour
{
    [SerializeField] BoxCollider2D alexWokenScene;
    [SerializeField] Canvas textCanvas;
    [SerializeField] GameObject textBox;
    private FlavourText flavourText;
    [SerializeField] PlayerMovement playerMovement;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        flavourText = GetComponent<FlavourText>();
        //Scene scene = SceneManager.GetActiveScene();

        //string sceneName = scene.name;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && alexWokenScene.enabled == true && SceneManager.GetSceneByName("Chapter 2").isLoaded)
        {
            playerMovement.enabled = true;
            playerMovement.DisableMovement();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (alexWokenScene.enabled == true)
        {
            textCanvas.enabled = true;
            textBox.SetActive(true);
            playerMovement.DisableMovement();
            playerMovement.enabled = false;
            flavourText.StartDialogue();
        }
        else if (alexWokenScene.enabled == false)
        {
            return;
        }
    }

}
