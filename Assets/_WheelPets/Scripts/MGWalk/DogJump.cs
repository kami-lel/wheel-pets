using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class DogJump : MonoBehaviour
{
    // General Controls
    public bool controlsEnabled = true; // Enable/disable functionality globally
    [SerializeField] private RectTransform grass; // Reference to the ground (UI element)
    [SerializeField] private float fallGravity = 1f; // Base gravity strength
    [SerializeField] private float fallMultiplier = 2.5f; // Gravity multiplier for falling speed

    // Jump Fields
    public float yVariation = 2f; // Vertical randomization range
    private float yStart; // Initial Y position
    private float xBoundLeft; // Left edge of the grass
    private float xBoundRight; // Right edge of the grass
    public Rigidbody2D body; // Rigidbody2D component for the player (assign in Inspector)
    public float jumpAmount = 5f; // Base jump force
    public AudioSource jumpSound; // Sound effect for jumping
    private bool isGrounded = true; // Tracks if the player is on the ground
    public float maxJumpHeight = 7f;

    // Variable Jump Height System
    private bool isJumping = false; // Tracks if the player is currently jumping
    private float jumpTimer = 0f; // Timer to measure jump hold duration
    public float maxJumpHoldTime = 0.2f; // Max time jump can be held
    public float initialJumpForce = 5f; // Initial jump force
    public float holdJumpForce = 2f; // Extra force applied while holding

    void Start()
    {
        if (body == null) Debug.LogError("Rigidbody2D (body) is null! Assign it in the Inspector.");
        if (jumpSound == null) Debug.LogWarning("Jump sound is not assigned!");

        if (grass != null)
        {
            Vector3[] corners = new Vector3[4];
            grass.GetWorldCorners(corners);
            xBoundLeft = corners[0].x;
            xBoundRight = corners[2].x;

            yStart = transform.position.y;
            Vector3 newPosition = transform.position;
            newPosition.y = yStart + Random.Range(-yVariation, yVariation);
            transform.position = newPosition;
        }
        else
        {
            Debug.LogError("Grass object is not assigned for movement calculations!");
        }

        // Disable controls initially (e.g., intro animation)
        controlsEnabled = false;
        StartCoroutine(EnableControlsAfterDelay(2f)); // Enable controls after 2 seconds
    }

    void Update()
    {
        if (!controlsEnabled) return;
        HandleJumpInput();
        HandleJumpRelease();
    }

    private void HandleJumpInput()
    {
        if (body == null || !isGrounded) return;

        if (Input.GetKeyDown(KeyCode.Space)) // 🛑 Mouse Click Removed, Spacebar Only
        {
            StartJump();
        }
    }

    private void HandleJumpRelease()
    {
        if (isJumping && Input.GetKeyUp(KeyCode.Space))
        {
            EndJumpEarly();
        }
    }

    private void StartJump()
    {
        isJumping = true;
        jumpTimer = 0f;
        ApplyInitialJump();
        if (jumpSound != null) jumpSound.Play();
    }

    private void ApplyInitialJump()
    {
        if (body != null)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, initialJumpForce);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        ApplyGravity();
        ProcessJumpHold();
    }

    private void ProcessJumpHold()
    {
        if (isJumping && jumpTimer < maxJumpHoldTime)
        {
            jumpTimer += Time.fixedDeltaTime;
            body.linearVelocity += new Vector2(0, holdJumpForce * Time.fixedDeltaTime);
        
            if (body.linearVelocity.y > maxJumpHeight)
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, maxJumpHeight);
            }
        }
    }

    private void EndJumpEarly()
    {
        isJumping = false;

        if (body != null && body.linearVelocity.y > 0)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, body.linearVelocity.y * 0.5f);
        }
    }

    private void ApplyGravity()
    {
        if (!isGrounded && body != null)
        {
            float gravityToApply = fallGravity * fallMultiplier;
            body.linearVelocity += new Vector2(0, -gravityToApply * Time.fixedDeltaTime);

            float maxFallSpeed = -10f;
            if (body.linearVelocity.y < maxFallSpeed)
            {
                body.linearVelocity = new Vector2(body.linearVelocity.x, maxFallSpeed);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
        }
    }

    public void DisableControls()
    {
        controlsEnabled = false;
    }

    private IEnumerator EnableControlsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        controlsEnabled = true;
    }
}
