using UnityEngine;
using UnityEngine.EventSystems;  // Included as requested, though not strictly required here

[RequireComponent(typeof(Rigidbody2D))]
public class ParkedStateChecker : MonoBehaviour
{
    [Header("Parked Settings")]
    [Tooltip("Speed below which the character is considered parked if grounded.")]
    [SerializeField] private float parkedSpeedThreshold = 0.1f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D _rb;

    /// <summary>
    /// True if the character is moving below _parkedSpeedThreshold and is grounded.
    /// </summary>
    public bool IsParked
    {
        get
        {
            if (!_rb) return false;  // Failsafe if Rigidbody2D is missing
            return IsGrounded() && _rb.linearVelocity.magnitude < parkedSpeedThreshold;
        }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Checks if the character is on the ground by overlapping a small circle with groundLayer.
    /// </summary>
    private bool IsGrounded()
    {
        if (!groundCheck) 
        {
            // If _groundCheck isn’t assigned, you might default to always grounded or handle differently
            return true;
        }
        var hit = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        return hit != null;
    }
}