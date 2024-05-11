using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;
    

    public void PlaySound()
    {
        audioSource.PlayOneShot(clip, volume);
    }
}
