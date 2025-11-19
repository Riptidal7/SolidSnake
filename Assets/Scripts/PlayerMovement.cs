using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 currentDirection = Vector2.right;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if (!context.performed)
            return;
        
        // Prevent diagonal movement (snake usually moves 4 directions)
        if (Mathf.Abs(input.x) > 0.1f)
            currentDirection = new Vector2(Mathf.Sign(input.x), 0f);
        else if (Mathf.Abs(input.y) > 0.1f)
            currentDirection = new Vector2(0f, Mathf.Sign(input.y));
    }
    
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + currentDirection * (GameParameters.SnakeMoveSpeed * Time.fixedDeltaTime));
    }
}
