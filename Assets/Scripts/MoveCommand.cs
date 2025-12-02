using UnityEngine;
using UnityEngine.InputSystem;

public class MoveCommand : ICommand
{
    PlayerMovement playerMovement;
    private InputAction.CallbackContext movement;
    private Grid grid;

    public MoveCommand(PlayerMovement player, InputAction.CallbackContext moveVector)
    {
        this.playerMovement = player;
        this.movement = moveVector;
    }
    
    public void Execute()
    {
        playerMovement.Move(movement);
    }
}
