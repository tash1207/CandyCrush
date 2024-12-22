using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI candyCaneText;
    [SerializeField] TextMeshProUGUI speedText;

    int candyCanesCollected = 0;
    int candyCanesTotal = 25;

    void UpdateScore()
    {
        candyCaneText.text = candyCanesCollected + " / " + candyCanesTotal;
        speedText.text = (8 + candyCanesCollected * 2) + " MPH";
    }

    public void CollectCandyCane()
    {
        candyCanesCollected++;
        UpdateScore();
    }

    public void EndGame()
    {
        candyCanesCollected = 0;
        speedText.text = "2 MPH";
    }
}
