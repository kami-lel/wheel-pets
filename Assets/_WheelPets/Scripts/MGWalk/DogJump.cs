using UnityEngine;
using TMPro;
using System.Collections;

public class DogJump : MonoBehaviour
{
    // Common Fields
    public bool controlsEnabled = true; // Enable/disable functionality globally
    [SerializeField] private RectTransform grass; // Reference to the grass (UI element)
    [SerializeField] private float fallGravity; // Gravity affecting fall speed (customizable)

    // Jump Fields
    public float yVariation = 2f; // Vertical randomization range
    private float yStart; // Initial Y position
    private float xBoundLeft; // Left edge of the grass
    private float xBoundRight; // Right edge of the grass
    public Rigidbody2D body; // Rigidbody2D component for the player (assign in Inspector)
    public float jumpAmount = 5f; // Adjust jump strength as needed
    public AudioSource jumpSound; // Sound effect for jumping
    private bool jumpRequested = false; // Input buffer for jump
    private bool isGrounded = true; // Tracks if the player is on the ground

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
            Debug.LogError("Grass object is not assigned for Arrow Key Movement!");
        }

        // Disable controls initially
        controlsEnabled = false;
        StartCoroutine(EnableControlsAfterDelay(2f)); // 2-second delay
    }

    void Update()
    {
        if (!controlsEnabled) return;
        HandleJumpInput();
    }

    void FixedUpdate()
    {
        ApplyGravity();
        ProcessJump();
    }

    private void HandleJumpInput()
    {
        if (body == null) return;

        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            jumpRequested = true;
            Debug.Log("Jump input buffered.");
        }
    }

    private void ProcessJump()
    {
        if (!jumpRequested || body == null) return;

        body.linearVelocity = new Vector2(body.linearVelocity.x, jumpAmount);
        Debug.Log("Player jumped!");

        if (jumpSound != null) jumpSound.Play();

        jumpRequested = false;
        isGrounded = false; // Player is no longer on the ground
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player has landed on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Player landed.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("target"))
        {
            controlsEnabled = false;
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


private void ApplyGravity()
{
    if (!isGrounded && body != null)
    {
        body.linearVelocity += new Vector2(0, -fallGravity * Time.fixedDeltaTime);

        // Optional: Limit max fall speed for more control
        float maxFallSpeed = -5f;  // Adjust for floatiness
        if (body.linearVelocity.y < maxFallSpeed)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, maxFallSpeed);
        }
    }
}

}