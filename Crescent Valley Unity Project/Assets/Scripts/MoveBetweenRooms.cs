using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenRooms : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector2 newPos;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

    [SerializeField] GameObject textBox;
    private PlayerMovement playerMovement;

    private bool closeToDoor = false;

    // Start is called before the first frame update
    void Start()
    {
        //textBox = GameObject.Find("Text box");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && closeToDoor == true)
        {
            //if (textBox.activeInHierarchy == true)
            //{
            //    textBox.SetActive(false);
            //}
            //playerMovement.enabled = true;
            //playerMovement.EnableMovement(gameObject.name);
            MovePlayer();
        }
    }

    public void MovePlayer()
    {
        player.transform.position = newPos;
        audioSource.PlayOneShot(clip, volume);
        
        if (textBox.activeSelf == true)
        {
            textBox.SetActive(false);
        }
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
