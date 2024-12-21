using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetection : MonoBehaviour
{
    [SerializeField] AudioClip crashSFX;
    [SerializeField] GameObject candyCanePerson;
    [SerializeField] Sprite brokenCandyCaneImage;
    [SerializeField] ParticleSystem crashParticles;

    float crashSoundEffectDelay = 0.2f;
    float reloadSceneDelay = 3.85f;
    float gameOverSpeed = 4f;

    bool preventCrashSoundEffect = false;
    bool hasCrashed = false;

    BackgroundMusic backgroundMusic;
    SurfaceEffector2D surfaceEffector2D;
    ScoreManager scoreManager;

    void Start()
    {
        backgroundMusic = FindObjectOfType<BackgroundMusic>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (!preventCrashSoundEffect && other.gameObject.tag == "Snowman")
        {
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            preventCrashSoundEffect = true;
            Invoke("AllowCrashSoundEffect", crashSoundEffectDelay);
        }
    }

    private void AllowCrashSoundEffect()
    {
        preventCrashSoundEffect = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!hasCrashed && other.tag == "Ground")
        {
            hasCrashed = true;

            // Audio
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            backgroundMusic.PlayEndGameMusic();

            // Visual
            FindObjectOfType<PlayerController>().DisableControls();
            candyCanePerson.GetComponent<SpriteRenderer>().sprite = brokenCandyCaneImage;
            crashParticles.Play();
            surfaceEffector2D.speed = gameOverSpeed;
            scoreManager.EndGame();

            Invoke("ReloadScene", reloadSceneDelay);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
