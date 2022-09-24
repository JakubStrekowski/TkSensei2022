using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip[] leftSounds;
    public AudioClip[] rightSounds;

    [SerializeField] private AudioSource leftAudioSource;
    [SerializeField] private AudioSource rightAudioSource;

    public void PlayLeft()
    {
        leftAudioSource.PlayOneShot(leftSounds[Random.Range(0, leftSounds.Length)]);
    }
    public void PlayRight()
    {
        rightAudioSource.PlayOneShot(rightSounds[Random.Range(0, rightSounds.Length)]);
    }
}
