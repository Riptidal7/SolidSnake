using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void Awake()
    {
        Subscribe();
    }
    
    public void Subscribe()
    {
        GameEvents.OnBorderHit += OnBorderHit;
        GameEvents.OnTailHit += OnTailHit;
    }
    
    public void OnBorderHit()
    {
        LoseGame();
    }

    public void OnTailHit()
    {
        LoseGame();
    }

    public void LoseGame()
    {
        Debug.Log("LoseGame");
        Debug.Log("Score: " + PlayerPrefs.GetInt("HighScore"));
    }
    
}
