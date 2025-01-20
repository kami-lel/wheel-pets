using UnityEngine;

public class ArrowKeyController : MonoBehaviour {
    public float moveSpeed = 5f; // Speed of the rock's movement
    public RectTransform grass; // Reference to the grass (UI element)
    private float xBoundLeft; // Left edge of the grass
    private float xBoundRight; // Right edge of the grass
    public float yVariation = 2f; // Vertical randomization range
    private float yStart; // Initial Y position

    void Start() {
        if (grass == null) {
            Debug.LogError("Grass object is not assigned!");
            return;
        }

        // Calculate the bounds of the grass
        Vector3[] corners = new Vector3[4];
        grass.GetWorldCorners(corners);
        xBoundLeft = corners[0].x; // Bottom-left corner
        xBoundRight = corners[2].x; // Top-right corner

        // Store the initial Y position
        yStart = transform.position.y;

        // Randomize the starting Y position
        Vector3 newPosition = transform.position;
        newPosition.y = yStart + Random.Range(-yVariation, yVariation);
        transform.position = newPosition;
    }

    void Update() {
        // Capture horizontal input from arrow keys
        float horizontalInput = 0;

        if (Input.GetKey(KeyCode.LeftArrow)) horizontalInput = 1;
        else if (Input.GetKey(KeyCode.RightArrow)) horizontalInput = -1;

        // Apply horizontal movement
        Vector3 movement = new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);
        transform.position += movement;

        // Check if the rock goes out of bounds on the left
        if (transform.position.x < xBoundLeft) {
            Vector3 newPosition = transform.position;
            newPosition.x = xBoundRight; // Reappear on the right side of the grass

            // Randomize the Y position for variety
            newPosition.y = yStart + Random.Range(-yVariation, yVariation);
            transform.position = newPosition;
        }
    }
}
