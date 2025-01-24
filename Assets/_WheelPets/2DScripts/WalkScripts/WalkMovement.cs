using UnityEngine;
using TMPro;

public class WalkMovement : MonoBehaviour
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
    public CompletedJumper jumper; // Reference to the jumper component
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
        if (jumper == null) Debug.LogWarning("Jumper is not assigned!");
        if (jumpSound == null) Debug.LogWarning("Jump sound is not assigned!");
    }

    void Update()
    {
        if (!controlsEnabled) return;

        HandleArrowKeyInput();
        HandleJumpInput();
    }

    void FixedUpdate()
    {
        ProcessJump();
    }

    private void HandleArrowKeyInput()
    {
        if (grass == null) return;

        float horizontalInput = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) horizontalInput = 1;
        else if (Input.GetKey(KeyCode.RightArrow)) horizontalInput = -1;

        Vector3 movement = new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);
        transform.position += movement;

        if (transform.position.x < xBoundLeft)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = xBoundRight;
            newPosition.y = yStart + Random.Range(-yVariation, yVariation);
            transform.position = newPosition;
        }
    }

    private void HandleJumpInput()
    {
        if (jumper == null) return;

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            jumpRequested = true;
            Debug.Log("Jump input buffered.");
        }
    }

    private void ProcessJump()
    {
        if (!jumpRequested || jumper == null) return;

        jumper.Jump();
        Debug.Log("Jump executed in FixedUpdate.");

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

            // Disable all controls
            controlsEnabled = false;
        }
    }

    public void DisableControls()
    {
        controlsEnabled = false;
    }
}
