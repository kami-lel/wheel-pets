using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerMovement2D))]
public class PlayerInput2D : MonoBehaviour
{
    private ICharacterMovement2D movement;

    private void Awake()
    {
        // Get reference to the movement component which implements ICharacterMovement2D
        movement = GetComponent<ICharacterMovement2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (movement == null) return;

        Vector2 move = context.ReadValue<Vector2>();
        float horizontal = move.x;
        float vertical   = move.y;

        // Feed input into the movement script
        movement.UpdateMovement(horizontal, vertical, false); // jump boolean is false here
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (movement == null) return;

        // We check if the button was pressed this frame
        if (context.performed)
        {
            movement.UpdateMovement(0, 0, true); // setting horizontal and vertical to 0 for jump 
        }
    }

    private void Update()
    {
        // If there's no movement component, do nothing
        if (movement == null) return;

        // If you are using the old Input system:
        float horizontal = Input.GetAxisRaw("Horizontal");  // e.g. A/D or Left/Right
        float vertical   = Input.GetAxisRaw("Vertical");    // e.g. W/S or Up/Down
        bool jump        = Input.GetButtonDown("Jump");     // space key or your chosen jump input

        // Feed input into the movement script
        movement.UpdateMovement(horizontal, vertical, jump);
    }
}
