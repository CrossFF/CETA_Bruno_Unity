using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> positiveClips;
    [SerializeField] private List<AudioClip> helpClips;
    [SerializeField] private AudioClip neutralBrunoClip;
    [SerializeField] private AudioClip positiveBrunoClip;
    [SerializeField] private AudioClip negativeBrunoClip;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPositiveClip()
    {
        // tomo un audio random de la lista
        // reprodusco el sonido
        int num = Random.Range(0, positiveClips.Count);
        audioSource.clip = positiveClips[num];
        audioSource.Play();
    }

    public void PlayNeutralBruno()
    {
        audioSource.clip = neutralBrunoClip;
        audioSource.Play();
    }

    public void PlayPositiveBruno()
    {
        audioSource.clip = positiveBrunoClip;
        audioSource.Play();
    }

    public void PlayNegativeBruno()
    {
        audioSource.clip = negativeBrunoClip;
        audioSource.Play();
    }
}
