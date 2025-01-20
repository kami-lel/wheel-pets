using UnityEngine;
using UnityEngine.InputSystem;  // new system namespace

[RequireComponent(typeof(PlayerMovement2D))]
public class PlayerInput2D : MonoBehaviour
{
    private ICharacterMovement2D movement;

    // Called when Unity initializes this component
    private void Awake()
    {
        movement = GetComponent<ICharacterMovement2D>();
    }

    // Suppose you have Input Actions set up for Move (Vector2) and Jump (Button).
    public void OnMove(InputAction.CallbackContext context)
    {
        if (movement == null) return;

        Vector2 move = context.ReadValue<Vector2>();
        float horizontal = move.x;
        float vertical   = move.y;
        
        // We only *apply* movement here if jump is not needed. 
        // Or we can just store them in private variables and apply them in Update. 
        // The new Input System is flexible.
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (movement == null) return;
        // We check if the button was pressed this frame
        if (context.performed)
        {
            // We might call something like:
            // movement.UpdateMovement(currentHorizontal, currentVertical, true);
        }
    }

    private void Update()
    {
        // If you want to call movement.UpdateMovement() every frame 
        // with the stored horizontal/vertical inputs plus 
        // a "jump" boolean if triggered. 
    }
}