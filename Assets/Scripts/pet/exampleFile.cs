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

    public void OnMove(InputAction.CallbackContext context)
    {
        if (movement == null) return;

        Vector2 move = context.ReadValue<Vector2>();
        float horizontal = move.x;
        float vertical   = move.y;
        
        // We only *apply* movement here if jump is not needed. 
        // Or we can just store them in private variables and apply them in Update.
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (movement == null) return;
        // We check if the button was pressed this frame
        if (context.performed)
        {
            // might call something like:
            // movement.UpdateMovement(currentHorizontal, currentVertical, true);
        }
    }

    private void Update()
    {
        // If we want to call movement.UpdateMovement() every frame 
        // with the stored horizontal/vertical inputs plus 
        // a "jump" boolean if triggered. 
    }
}