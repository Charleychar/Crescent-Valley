using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenRooms : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector2 newPos;
    //[SerializeField] FlavourText flavourText;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    [SerializeField] GameObject textBox;
    private PlayerMovement playerMovement;
    private FlavourText flavourText;

    private bool closeToDoor = false;

    // Start is called before the first frame update
    void Start()
    {
        //textBox = GameObject.Find("Text box");
        playerMovement = FindObjectOfType<PlayerMovement>();
        flavourText = FindObjectOfType<FlavourText>();
        //flavourText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //print("Input.GetKeyDown(KeyCode.E): " + Input.GetKeyDown(KeyCode.E) + ", closeToDoor: " + closeToDoor);
        if (Input.GetKeyDown(KeyCode.E) && closeToDoor == true)
        {           
            MovePlayer();
        }
    }

    public void MovePlayer()
    {
        //flavourText.enabled = false;
        player.transform.position = newPos;
        audioSource.PlayOneShot(clip, volume);
        playerMovement.enabled = true;
        playerMovement.EnableMovement(gameObject.name);      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        closeToDoor = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        closeToDoor = false;
    }
}
