using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            Debug.Log("Candy Cane");
            other.gameObject.GetComponent<PlayerController>().IncreaseSpeed();
            Destroy(gameObject);
        }
    }
}
