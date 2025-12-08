using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
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
        UpdateScoreText();
        if (score == 10)
            GameEvents.On10BoxCollected?.Invoke();
    }
    
    
    
    public void SaveHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void UpdateScoreText()
    {
        scoreText.text = score.ToString("D3");
    }
}
