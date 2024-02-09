using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenFloors : MonoBehaviour
{
    GameObject firstToGround;
    [SerializeField] GameObject player;
    [SerializeField] Transform newPos;
    
    
    // Start is called before the first frame update
    void Start()
    {
        firstToGround = GameObject.Find("FirstToGround");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.transform.position == firstToGround.transform.position)
        {
            player.transform.position = newPos.position;
            //PositionCheck();
        }
    }

    //public void PositionCheck()
    //{
    //    if (player.transform.position = newPos.position)
    //    {
    //        print("moved");
    //    }
    //}
}
