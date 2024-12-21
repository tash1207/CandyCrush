using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDetection : MonoBehaviour
{
    [SerializeField] AudioClip crashSFX;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground")
        {
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
        }
    }
}
