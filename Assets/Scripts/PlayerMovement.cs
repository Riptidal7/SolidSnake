using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public Grid grid;
    
    private Vector3Int gridPosition;
    private Vector2Int currentDirection = Vector2Int.right;

    private float moveTimer;

    void Start()
    {
        gridPosition = grid.WorldToCell(transform.position);
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if (!context.performed)
            return;
        
        if (Mathf.Abs(input.x) > 0.1f)
            currentDirection = new Vector2Int((int)Mathf.Sign(input.x), 0);
        else if (Mathf.Abs(input.y) > 0.1f)
            currentDirection = new Vector2Int(0, (int)Mathf.Sign(input.y));
    }
    
    private void Update()
    {
        moveTimer += Time.deltaTime;
        if (moveTimer >= GameParameters.SnakeMoveInterval)
        {
            moveTimer = 0f;
            Step();
        }
    }

    private void Step()
    {
        gridPosition += new Vector3Int(currentDirection.x, currentDirection.y, 0);
        
        Vector3 worldPos = grid.GetCellCenterWorld(gridPosition);
        
        transform.position = worldPos;
    }
}
