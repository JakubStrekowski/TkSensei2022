using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip[] leftSounds;
    public AudioClip[] rightSounds;

    private AudioSource audioSource;

    private void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayLeft()
    {
        audioSource.PlayOneShot(leftSounds[Random.Range(0, leftSounds.Length)]);
    }
    public void PlayRight()
    {
        audioSource.PlayOneShot(rightSounds[Random.Range(0, rightSounds.Length)]);
    }
}
