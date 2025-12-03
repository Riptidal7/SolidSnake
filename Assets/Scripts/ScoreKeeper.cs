using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text scoreText;
    public int score = 0;

    public void Awake()
    {
        Subscribe();
    }

    public void Subscribe()
    {
        GameEvents.OnBoxCollected += OnBoxCollected;
    }

    public void OnBoxCollected()
    {
        score++;
        scoreText.text = score.ToString("D3");
        SaveHighScore();
    }
    
    public void SaveHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
