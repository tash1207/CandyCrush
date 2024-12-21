using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] AudioClip collectibleSound;

    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            scoreManager.CollectCandyCane();
            other.gameObject.GetComponent<PlayerController>().IncreaseSpeed();
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(collectibleSound);
            Destroy(gameObject);
        }
    }
}
