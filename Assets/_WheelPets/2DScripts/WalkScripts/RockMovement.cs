using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the rock's movement
    public RectTransform panel; // Reference to the panel (UI element)

    private float xBoundLeft; // Left edge of the panel
    private float xBoundRight; // Right edge of the panel

    void Start()
    {
        if (panel == null)
        {
            Debug.LogError("Panel object is not assigned!");
            return;
        }

        // Calculate the bounds of the panel
        Vector3[] corners = new Vector3[4];
        panel.GetWorldCorners(corners);
        xBoundLeft = corners[0].x; // Bottom-left corner
        xBoundRight = corners[2].x; // Top-right corner
    }

    void Update()
    {
        HandleRockMovement();
    }

    private void HandleRockMovement()
    {
        // Capture horizontal input from arrow keys
        float horizontalInput = 0;

        if (Input.GetKey(KeyCode.LeftArrow)) horizontalInput = -1;
        else if (Input.GetKey(KeyCode.RightArrow)) horizontalInput = 1;

        // Apply horizontal movement
        Vector3 movement = new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);
        transform.position += movement;

        // Check if the rock goes out of bounds on the left
        if (transform.position.x < xBoundLeft)
        {
            Vector3 newPosition = transform.position;
            newPosition.x = xBoundRight; // Reappear on the right side of the panel
            transform.position = newPosition;
        }
    }
}
