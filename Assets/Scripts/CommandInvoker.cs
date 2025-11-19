using UnityEngine;
using UnityEngine.InputSystem;

public class CommandInvoker : MonoBehaviour
{
    private PlayerMovement playerMovement;
    
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        ICommand moveCmd = new MoveCommand(playerMovement, context);
        moveCmd.Execute();
    }
}
