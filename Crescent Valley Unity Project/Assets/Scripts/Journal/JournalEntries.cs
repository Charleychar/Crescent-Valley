using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalEntries : MonoBehaviour
{
    [SerializeField] GameObject player;
    //[SerializeField] Canvas entryAddedCanvas;
    public GameObject entryCanvas;
    [SerializeField] Image entryAdded;
    [SerializeField] Image respectiveEntry;
    bool tree = false;

    public AudioSource audioSource;
    public AudioClip writingSound;
    public float volume = 0.5f;
    


    private void Awake()
    {
        entryCanvas = GameObject.Find("Entry Added");
    }

    // Start is called before the first frame update
    void Start()
    {
        respectiveEntry.enabled = false;
        entryCanvas.SetActive(false);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && tree == true)
        {
            entryCanvas.SetActive(true);
            entryAdded.enabled = true;
            print("enabled");
            audioSource.PlayOneShot(writingSound, volume);

            //entryAdded.color = new Color(entryAdded.color.r, entryAdded.color.g, entryAdded.color.b, _alpha);

            //print("interact");
            StartCoroutine("EntryAddedUIAppear");
            respectiveEntry.enabled = true;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision) 
    {

        tree = true;
      
        //FindObjectOfType<Player>();
        //StartCoroutine("EntryAddedUIAppear");
        //respectiveEntry.enabled = true;
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tree = false;

        //if (respectiveEntry.enabled == true)
        //{
        //    StartCoroutine("EntryAddedUIDisappear");
        //}
        
        
    }

    private IEnumerator EntryAddedUIAppear()
    {
        
        print("lmao");
        
        for (float _alpha = entryAdded.color.a; _alpha <= 1; _alpha += Time.deltaTime)
        {
            entryAdded.color = new Color(entryAdded.color.r, entryAdded.color.g, entryAdded.color.b, _alpha);

            yield return null;
            
            //StartCoroutine("EntryAddedUIDisappear");
        }

        StartCoroutine("EntryAddedUIDisappear");
    }

    private IEnumerator EntryAddedUIDisappear()
    {
        for (float _alpha = entryAdded.color.a; _alpha >= 0; _alpha -= Time.deltaTime)
        {
            entryAdded.color = new Color(entryAdded.color.r, entryAdded.color.g, entryAdded.color.b, _alpha);
            yield return null;
        }

        gameObject.SetActive(false);
        //entryAdded.enabled = false;
    }

}
