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

    void Start() => ChangeState(State.Start);

    public void ChangeState(State newState)
    {
        state = newState;
        switch (newState)
        {
            case State.Start:
                MainMenu.SetActive(true);
                GameUI.SetActive(false);
                Results.SetActive(false);
                CollectibleBox.SetActive(false);
                Player.SetActive(false);
                break;
            case State.Game:
                MainMenu.SetActive(false);
                Results.SetActive(false);
                CollectibleBox.SetActive(true);
                Player.SetActive(true);
                GameUI.SetActive(true);
                break;
            case State.Results:
                GameUI.SetActive(false);
                Player.SetActive(false);
                CollectibleBox.SetActive(false);
                Results.SetActive(true);
                break;
        }
    }
}
