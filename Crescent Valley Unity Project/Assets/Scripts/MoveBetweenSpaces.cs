using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBetweenSpaces : MonoBehaviour
{
    [SerializeField] Canvas fadeToBlack;
    [SerializeField] float fadeSpeed = 5f;

    bool fade = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        FadeTransition();
    }


    public IEnumerator FadeTransition(bool fade = true, float fadeSpeed = 5)
    {
        yield return new WaitForEndOfFrame();
    }
}
