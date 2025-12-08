using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameStates GameStates;
    public GameObject Player;
    public BoxTailManager BoxTailManager;
    public ScoreDisplay ScoreDisplay;
    public ScoreKeeper ScoreKeeper;
    public TextMeshProUGUI ResultText;
    public GameObject ExtractionZonePrefab;
    public BoxCollider2D GridArea;
    public Grid Grid;
    public AudioClip LoseSound;
    public AudioClip WinSound;
    
    public void Subscribe()
    {
        GameEvents.OnBorderHit += OnBorderHit;
        GameEvents.OnTailHit += OnTailHit;
        GameEvents.OnExtraction += OnExtraction;
        GameEvents.On10BoxCollected += On10BoxCollected;
    }

    public void Unsubscribe()
    {
        GameEvents.OnBorderHit -= OnBorderHit;
        GameEvents.OnTailHit -= OnTailHit;
        GameEvents.OnExtraction -= OnExtraction;
        GameEvents.On10BoxCollected -= On10BoxCollected;
    }
    
    public void OnBorderHit()
    {
        LoseGame();
    }

    public void OnTailHit()
    {
        LoseGame();
    }

    public void OnExtraction()
    {
        WinGame();
    }

    public void On10BoxCollected()
    {
        Vector3? ExtractionSpot = RandomGridSpot();
        if (ExtractionSpot != null)
            Instantiate(ExtractionZonePrefab, ExtractionSpot.Value, Quaternion.identity);
    }
    

    public void LoseGame()
    {
        ResultText.text = "Game Over";
        ScoreDisplay.UpdateScoreResultsText();
        GoToResults();
        AudioManager.Instance.PlayGameEndSFX(LoseSound);
    }

    public void WinGame()
    {
        ResultText.text = "You Win";
        ScoreKeeper.SaveHighScore();
        ScoreDisplay.UpdateScoreResultsText();
        GoToResults();
        AudioManager.Instance.PlayGameEndSFX(WinSound);
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
    
    private Vector3? RandomGridSpot()
    {
        Bounds bounds = GridArea.bounds;

        for (int i = 0; i < 200; i++)
        {
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            Vector3 randomWorldPos = new Vector3(x, y);
        
            Vector3Int cell = Grid.WorldToCell(randomWorldPos);
        
            if (!GridChecker.IsOccupied(cell))
            {
                Vector3 snappedPos = Grid.GetCellCenterWorld(cell);
                GridChecker.Add(cell);
                return snappedPos;
            }
        }

        return null;
    }
    
    public void OnButtonClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode(); // or: UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit(); // quits the built game
#endif
    }
    
    
}
