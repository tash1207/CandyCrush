using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] ParticleSystem fireworksEffect;

    bool finishLineCrossed = false;
    float gameOverDelay = 5.5f;

    BackgroundMusic backgroundMusic;
    PlayerController playerController;

    void Start()
    {
        backgroundMusic = FindObjectOfType<BackgroundMusic>();
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!finishLineCrossed && other.tag == "Player")
        {
            finishLineCrossed = true;
            backgroundMusic.PlayFinishLineMusic();
            fireworksEffect.Play();
            Invoke("ShowGameOverScreen", gameOverDelay);
        }
    }

    private void ShowGameOverScreen()
    {
        playerController.DisableControls();
        playerController.FreezePlayer();
        gameOverScreen.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
