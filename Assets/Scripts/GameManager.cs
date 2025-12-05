using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameStates GameStates;
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
        GoToResults();
    }

    public void GoToGame()
    {
        GameStates.ChangeState(GameStates.State.Game);
    }

    public void GoToResults()
    {
        GameStates.ChangeState(GameStates.State.Results);
    }
    
}
