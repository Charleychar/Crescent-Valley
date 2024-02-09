using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenFloors : MonoBehaviour
{
    //triggers
    GameObject firstToGround;
    GameObject groundToFirst;
    GameObject firstToTop;
    GameObject topToFirst;

    [SerializeField] GameObject player;
    
    //spawn points
    [SerializeField] Transform groundNewPos;
    [SerializeField] Transform firstNewPos;
    [SerializeField] Transform topNewPos;
    [SerializeField] Transform firstStairsNewPos;
    
    
    // Start is called before the first frame update
    void Start()
    {
        firstToGround = GameObject.Find("FirstToGround");
        groundToFirst = GameObject.Find("GroundToFirst");
        firstToTop = GameObject.Find("FirstToTop");
        topToFirst = GameObject.Find("TopToFirst");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.transform.position == firstToGround.transform.position)
        {
            player.transform.position = groundNewPos.position;    
        }

        if (this.gameObject.transform.position == groundToFirst.transform.position)
        {
            player.transform.position = firstNewPos.position;
        }

        if (this.gameObject.transform.position == firstToTop.transform.position)
        {
            player.transform.position = topNewPos.position;
        }

        if (this.gameObject.transform.position == topToFirst.transform.position)
        {
            player.transform.position = firstStairsNewPos.position;
        }
    }

    
}
