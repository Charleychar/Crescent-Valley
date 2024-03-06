using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    [SerializeField] GameObject respectiveNotification;

    Animator anim;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        respectiveNotification.SetActive(false);
        anim = respectiveNotification.GetComponent<Animator>();
        //respectiveNotification.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        respectiveNotification.SetActive(true);

        anim.SetTrigger("playerInRange");

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        respectiveNotification.SetActive(false);
    }
}
