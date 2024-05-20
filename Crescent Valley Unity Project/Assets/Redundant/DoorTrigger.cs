using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] float interactRange = 1f;
    [SerializeField] GameObject player;
    float distanceToPlayer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (distanceToPlayer <= interactRange && Input.GetKeyDown(KeyCode.E))
        {
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
