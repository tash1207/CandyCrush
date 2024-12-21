using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioClip mainMenuMusic;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMenuMusic();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    public void PlayMenuMusic()
    {
        audioSource.clip = mainMenuMusic;
        audioSource.Play();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
