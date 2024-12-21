using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI candyCaneText;
    [SerializeField] TextMeshProUGUI speedText;

    int candyCanesCollected = 0;
    int candyCanesTotal = 20;

    void UpdateScore()
    {
        candyCaneText.text = candyCanesCollected + " / " + candyCanesTotal;
        speedText.text = (10 + candyCanesCollected * 5) + " MPH";
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
