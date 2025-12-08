using UnityEngine;

public class GameStates : MonoBehaviour
{
    public enum State {Start, Game, Results}

    public State state;
    
    public GameObject MainMenu;
    public GameObject GameUI;
    public GameObject Results;
    public GameObject Player;
    public GameObject CollectibleBox;
    
    public AudioClip MenuMusic;
    public AudioClip GameMusic;

    void Start() => ChangeState(State.Start);

    public void ChangeState(State newState)
    {
        state = newState;
        switch (newState)
        {
            case State.Start:
                StartScreen();
                break;
            case State.Game:
                GameScreen();
                break;
            case State.Results:
                ResultsScreen();
                break;
        }
    }

    public void StartScreen()
    {
        AudioManager.Instance.StopMusic();
        MainMenu.SetActive(true);
        GameUI.SetActive(false);
        Results.SetActive(false);
        CollectibleBox.SetActive(false);
        Player.SetActive(false);
        AudioManager.Instance.PlayMenuMusic(MenuMusic);
    }
    
    public void GameScreen()
    {
        AudioManager.Instance.StopMusic();
        MainMenu.SetActive(false);
        Results.SetActive(false);
        CollectibleBox.SetActive(true);
        Player.SetActive(true);
        GameUI.SetActive(true);
        AudioManager.Instance.PlayBackgroundMusic(GameMusic);
    }

    public void ResultsScreen()
    {
        AudioManager.Instance.StopMusic();
        GameUI.SetActive(false);
        Player.SetActive(false);
        CollectibleBox.SetActive(false);
        Results.SetActive(true);
    }
}
