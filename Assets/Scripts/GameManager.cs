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
    }
    
    public void OnBorderHit(GameEvents.OnBorderHitArgs obj)
    {
        if (!obj.inBorder)
        {
            LoseGame();
        }
    }

    public void LoseGame()
    {
        print("LoseGame");
    }
}
