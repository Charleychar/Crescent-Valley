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
    [SerializeField] BoxCollider2D barrier;
    [SerializeField] BoxCollider2D alexDoor;
    
    
    
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
            playerMovement.EnableMovement();
        }

        if (alexWokenScene.enabled == true)
        {
            alexDoor.enabled = false;
        }
        else if (alexWokenScene.enabled == false)
        {
            alexDoor.enabled = true;
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
            barrier.enabled = false;          
            return;         
        }
    }

}
