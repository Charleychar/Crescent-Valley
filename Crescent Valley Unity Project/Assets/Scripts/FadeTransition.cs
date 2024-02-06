using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeTransition : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    public GameObject blackOverlay;

    
    // Start is called before the first frame update
    void Start()
    {
        blackOverlay = GameObject.Find("FadeToBlack");
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        canvas.enabled = true;
        print("triggered");
        StartCoroutine(FadeTransitionToBlack());
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(FadeTransitionToBlack(false));
    }


    public IEnumerator FadeTransitionToBlack(bool fade = true, float fadeSpeed = 5)
    {
        print("coroutine");
        Color objectColor = blackOverlay.GetComponent<Image>().color;
        float fadeAmount;

        if (fade == true)
        {
            while (blackOverlay.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOverlay.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }else 
        {
            while (blackOverlay.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOverlay.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }

    //public IEnumerator FadeTransitionAwayFromBlack(bool fade = true, float fadeSpeed = 5)
    //{
    //    Color objectColor = blackOverlay.GetComponent<Image>().color;
    //    float fadeAmount;

    //    if (fade == false)
    //    {
    //        while (blackOverlay.GetComponent<Image>().color.a > 0)
    //        {
    //            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

    //            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
    //            blackOverlay.GetComponent<Image>().color = objectColor;
    //            yield return null;
    //        }
    //    }
    //}
}
