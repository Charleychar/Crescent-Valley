using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IdaNoiseScene : MonoBehaviour
{
    private CutsceneTrigger cutceneTrigger;

    [SerializeField] BoxCollider2D diningScene1;
    [SerializeField] BoxCollider2D diningScene2;
    [SerializeField] BoxCollider2D idaFlowerScene;
    [SerializeField] GameObject player;
    [SerializeField] Vector2 newPos;

    void Start()
    {
        cutceneTrigger = GetComponent<CutsceneTrigger>();
    }

    
    void Update()
    {

    }

    public void StartIdaScene()
    {

        if (diningScene1.enabled == true && diningScene2.enabled == false)
        {
            StartScene();
        }
        else if (diningScene1.enabled == false && diningScene2.enabled == true)
        {
            StartScene();
        }
        else
        {
            return;
        }
    }





    public void StartScene()
    {
        SceneManager.LoadScene(2);

        //cutceneTrigger.TriggerCutscene();
        //cutceneTrigger.TriggerPortraits();
        //player.transform.position = newPos;

        //diningScene1.enabled = false;
        //diningScene2.enabled = false;
    }
}
