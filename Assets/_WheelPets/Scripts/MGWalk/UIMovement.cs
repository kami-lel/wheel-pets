using UnityEngine;
using TMPro;
using System.Collections;

public class UIMovement : MonoBehaviour
{
    // Common Fields
    public bool controlsEnabled = true; // Enable/disable functionality globally

    // Arrow Key Movement Fields
    public float moveSpeed = 5f; // Speed of horizontal movement
    public RectTransform grass; // Reference to the grass (UI element)
    private float xBoundLeft; // Left edge of the grass
    private float xBoundRight; // Right edge of the grass
    public float yVariation = 2f; // Vertical randomization range
    private float yStart; // Initial Y position

    // Jump Fields
    public Rigidbody2D body; // Rigidbody2D component for the player (assign in Inspector)
    public float jumpAmount = 5f; // Adjust jump strength as needed
    public AudioSource jumpSound; // Sound effect for jumping
    private bool jumpRequested = false; // Input buffer for jump

    // Completion Fields
    [SerializeField] private TextMeshProUGUI completionText; // The TextMeshProUGUI to display the message

    void Start()
    {
        // Setup for Arrow Key Movement
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

        // Setup for Jump Functionality
        if (body == null) Debug.LogError("Rigidbody2D (body) is null! Assign it in the Inspector.");
        if (jumpSound == null) Debug.LogWarning("Jump sound is not assigned!");

        // Disable controls initially
        controlsEnabled = false;
        StartCoroutine(EnableControlsAfterDelay(2f)); // 2-second delay
    }

    void Update()
    {
        if (!controlsEnabled) return;

        HandleAutoMovement();
        HandleJumpInput();
    }

    void FixedUpdate()
    {
        ProcessJump();
    }

    private void HandleAutoMovement()
    {
        if (grass == null) return;

        // Automatically move the UI dog to the left
        float horizontalMovement = -moveSpeed * Time.deltaTime;

        // Apply movement
        transform.position += new Vector3(horizontalMovement, 0, 0);

        // If the UI dog moves past the left bound, reset it to the right
        if (transform.position.x < xBoundLeft)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = xBoundRight; // Reset to right side
            newPosition.y = yStart + Random.Range(-yVariation, yVariation); // Add slight vertical variation
            transform.position = newPosition;
        }
    }

    private void HandleJumpInput()
    {
        if (body == null) return;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other object is the target
        if (other.CompareTag("target"))
        {
            if (completionText != null)
            {
                completionText.text = "You finished walking!";
            }
            else
            {
                Debug.LogError("CompletionText is not assigned in the Inspector.");
            }

            // Increment the timesPetWalked stat
            PlayerData data = Data.GetPlayerData();
            data.timesPetWalked++;
            Data.SavePlayerDataToFile();

            // Disable all controls
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
}
