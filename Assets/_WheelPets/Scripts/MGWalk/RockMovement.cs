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
    // Move the rocks left
    float horizontalMovement = moveSpeed * Time.deltaTime;

    // Apply movement
    transform.position += new Vector3(horizontalMovement, 0, 0);

    // If the rock moves past the left bound, reset it to the right
    if (transform.position.x < xBoundLeft)
    {
        Vector3 newPosition = transform.position;
        newPosition.x = xBoundRight; // Respawn on the right side
        transform.position = newPosition;
    }
}


}
