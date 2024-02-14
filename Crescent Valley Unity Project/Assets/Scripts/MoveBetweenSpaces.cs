using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenSpaces : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector2 newPos;
    [SerializeField] float timeToTransition;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("TransitionLocation", timeToTransition);
    }

    public void TransitionLocation()
    {
        player.transform.position = newPos;
    }
}
