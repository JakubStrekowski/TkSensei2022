using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] stoneSounds;

    public void PlayRandom()
    {
        audioSource.PlayOneShot(stoneSounds[Random.Range(0, stoneSounds.Length)]);
    }
}
