using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
}
