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
        GameEvents.OnBorderHit += OnBorderHit;
        GameEvents.OnTailHit += OnTailHit;
    }

    

    public void Unsubscribe()
    {
        GameEvents.OnBoxCollected -= OnBoxCollected;
        GameEvents.OnBorderHit -= OnBorderHit;
        GameEvents.OnTailHit -= OnTailHit;
    }

    public void OnBoxCollected()
    {
        score++;
        scoreText.text = score.ToString("D3");
        SaveHighScore();
    }
    
    public void OnBorderHit()
    {
        score = 0;
        scoreText.text = score.ToString("D3");
    }

    public void OnTailHit()
    {
        score = 0;
        scoreText.text = score.ToString("D3");
    }
    
    
    
    public void SaveHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}
