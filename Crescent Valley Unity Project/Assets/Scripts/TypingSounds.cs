using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] typingSounds;
    private AudioClip sound;
    public float volume = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayTypingSFX()
    {
        int index = Random.Range(0, typingSounds.Length);
        sound = typingSounds[index];

        audioSource.clip = sound;
        audioSource.PlayOneShot(sound, volume);
    }
}
