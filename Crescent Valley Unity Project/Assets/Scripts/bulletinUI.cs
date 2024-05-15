using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletinUI : MonoBehaviour
{
    [SerializeField] Canvas bulletin;
    [SerializeField] Image bulletinDay;
    [SerializeField] Image bulletinNight;
    [SerializeField] BoxCollider2D cutsceneCheck;
    [SerializeField] PlayerMovement playerMovement;

    bool bulletinTrigger = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        bulletin.enabled = false;
        bulletinDay.enabled = false;
        bulletinNight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && bulletinTrigger == true && bulletin.enabled == false)
        {
            BulletinUI();
            playerMovement.DisableMovement();
        }
        else if (Input.GetKeyDown(KeyCode.E) && bulletin.enabled == true)
        {
            bulletin.enabled = false;
            bulletinDay.enabled = false;
            bulletinNight.enabled = false;

            playerMovement.EnableMovement(gameObject.name);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        bulletinTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bulletinTrigger = false;
    }

    public void BulletinUI()
    {
        print("bulletin");
        bulletin.enabled = true;

        if (cutsceneCheck.enabled == true)
        {
            bulletinDay.enabled = true;
        }
        else if (cutsceneCheck.enabled == false)
        {
            bulletinNight.enabled = true;
        }
    }
}
