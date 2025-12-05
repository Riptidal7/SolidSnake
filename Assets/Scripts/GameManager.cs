using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameStates GameStates;
    public GameObject Player;
    public BoxTailManager BoxTailManager;
    
    public void Subscribe()
    {
        GameEvents.OnBorderHit += OnBorderHit;
        GameEvents.OnTailHit += OnTailHit;
    }

    public void Unsubscribe()
    {
        GameEvents.OnBorderHit -= OnBorderHit;
        GameEvents.OnTailHit -= OnTailHit;
    }
    
    public void OnBorderHit()
    {
        Debug.Log("OnBorderHit");
        LoseGame();
    }

    public void OnTailHit()
    {
        Debug.Log("OnTailHit");
        LoseGame();
    }

    public void LoseGame()
    {
        GoToResults();
    }

    public void GoToGame()
    {
        Unsubscribe();
        ResetGame();
        GameStates.ChangeState(GameStates.State.Game);
        Subscribe();
    }

    public void GoToResults()
    {
        Unsubscribe();
        GameStates.ChangeState(GameStates.State.Results);
    }

    public void ResetGame()
    {
        var movement = Player.GetComponent<PlayerMovement>();
        movement.ResetMovement();
        Player.transform.position = new Vector3(0, 0, 0);
        BoxTailManager.ResetSnake();
    }
    
    
}
