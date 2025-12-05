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
                //make start screen visible here
                //ensure no other screens visible
                break;
            case State.Game:
                //make game screen visible
                break;
            case State.Results:
                //stop game timer/ other mechanics
                //turn on results screen
                //turn off game screen
                break;
        }
    }
}
