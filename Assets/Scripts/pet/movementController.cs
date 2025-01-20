using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D _rb;
    private Animator _animator;
    
    private bool _isFacingRight = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal"); // using var for a float
        var jump = Input.GetButtonDown("Jump");          // using var for a bool

        UpdateMovement(horizontal, jump);
    }

    private void UpdateMovement(float horizontal, bool jump)
    {
        // Flip logic
        if ((horizontal > 0 && !_isFacingRight) || (horizontal < 0 && _isFacingRight))
        {
            Flip();
        }

        // We retrieve the current linearVelocity (replacing the obsolete .velocity).
        var velocity = _rb.linearVelocity;  

        // Update horizontal speed
        velocity.x = horizontal * moveSpeed;

        // Jump, if grounded
        if (jump && IsGrounded())
        {
            velocity.y = 0f;         // reset vertical velocity to ensure consistent jump
            velocity.y += jumpForce;
        }

        // Reassign the updated velocity
        _rb.linearVelocity = velocity;

        // Update animations, if needed
        if (_animator)
        {
            _animator.SetFloat("Speed", Mathf.Abs(velocity.x));
        }
    }

    private bool IsGrounded()
    {
        if (groundCheck == null) 
        {
            // If no groundCheck is assigned, either treat as always grounded or handle differently
            return true;
        }

        // Check for ground using an overlap circle
        var hit = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        return (hit != null);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
