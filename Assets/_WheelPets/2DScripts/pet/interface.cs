using UnityEngine;

public interface ICharacterMovement2D
{
    /// <summary>
    /// Updates the character movement based on horizontal/vertical inputs and jump.
    /// </summary>
    /// <param name="horizontal">Movement input along the horizontal axis (e.g., -1 to 1)</param>
    /// <param name="vertical">Movement input along the vertical/forward-back axis (e.g., -1 to 1)</param>
    /// <param name="jump">True if jump was triggered this frame, otherwise false.</param>
    void UpdateMovement(float horizontal, float vertical, bool jump);

    /// <summary>
    /// Current speed magnitude (for animation or UI).
    /// </summary>
    float CurrentSpeed { get; }

    /// <summary>
    /// Whether the character is on the ground or not.
    /// </summary>
    bool IsGrounded { get; }

    /// <summary>
    /// Whether the character is currently facing right (can be used for flipping sprites).
    /// </summary>
    bool IsFacingRight { get; }
}