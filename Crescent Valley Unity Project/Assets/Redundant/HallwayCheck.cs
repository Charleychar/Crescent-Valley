using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayCheck : MonoBehaviour
{
    public bool InHallway = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        InHallway = true;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        InHallway = false;
    }
}
