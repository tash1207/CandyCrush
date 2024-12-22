using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    bool finishLineCrossed = false;
    float reloadSceneDelay = 5.5f;

    BackgroundMusic backgroundMusic;

    void Start()
    {
        backgroundMusic = FindObjectOfType<BackgroundMusic>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!finishLineCrossed && other.tag == "Player")
        {
            finishLineCrossed = true;
            backgroundMusic.PlayFinishLineMusic();
            // TODO: Freeze the player and have some fun animation.
            Invoke("ReloadScene", reloadSceneDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
