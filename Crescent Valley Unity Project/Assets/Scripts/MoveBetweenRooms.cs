using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenRooms : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector2 newPos;
    

    private bool closeToDoor = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && closeToDoor == true)
        {
            MovePlayer();
        }
    }

    public void MovePlayer()
    {
        player.transform.position = newPos;
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
