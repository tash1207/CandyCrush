using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] AudioClip levelMusic;
    [SerializeField] AudioClip endGameMusic;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayLevelMusic();
    }

    public void PlayLevelMusic()
    {
        audioSource.clip = levelMusic;
        audioSource.Play();
    }

    public void PlayEndGameMusic()
    {
        audioSource.clip = endGameMusic;
        audioSource.Play();
    }
}
