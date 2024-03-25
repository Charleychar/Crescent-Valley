using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    [SerializeField] GameObject respectiveNotification;
    [SerializeField] GameObject entryItem;

    Animator anim;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        respectiveNotification.SetActive(false);
        anim = respectiveNotification.GetComponent<Animator>();
        respectiveNotification.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (entryItem.activeInHierarchy == false)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        respectiveNotification.SetActive(true);
        respectiveNotification.GetComponent<SpriteRenderer>().color += new Color(0, 0, 0, 1);
        anim.SetTrigger("playerInRange");

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        respectiveNotification.SetActive(false);
    }
}
