using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer SnakeSpriteRenderer;
    
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocity = moveInput * GameParameters.SnakeMoveSpeed;
        KeepOnScreen();
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    
    private void KeepOnScreen()
    {
        SnakeSpriteRenderer.transform.position =
            SpriteTools.ConstrainToScreen(SnakeSpriteRenderer);
    }
}
