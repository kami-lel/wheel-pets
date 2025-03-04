using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public float moveSpeed = 5f;            // Speed the rock moves left
    public RectTransform background;        // Reference to the background image's RectTransform

    private float xBoundLeft;                // Left edge of the background (local space)
    private float xBoundRight;               // Right edge of the background (local space)
    private bool canMove = false;            // When true, rock starts moving

    public float respawnOffset = 100f;       // Optional buffer to spawn slightly offscreen right

    void Start()
    {
        if (background == null)
        {
            Debug.LogError("Background object is not assigned!");
            return;
        }

        UpdateBackgroundBounds();
        StartCoroutine(EnableMovementAfterDelay(2f));  // Optional delay before rocks move
    }

    void Update()
    {
        if (canMove)
        {
            UpdateBackgroundBounds();
            HandleRockMovement();
        }
    }

    private System.Collections.IEnumerator EnableMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

    private void UpdateBackgroundBounds()
    {
        // Background is UI so we use its rect
        xBoundLeft = background.rect.xMin;
        xBoundRight = background.rect.xMax;

        // Optional debug log
        // Debug.Log($"Background Bounds - Left: {xBoundLeft}, Right: {xBoundRight}");
    }

    private void HandleRockMovement()
    {
        float horizontalMovement = moveSpeed * Time.deltaTime;

        // Move the rock left (using localPosition if the rock is a UI element inside the same parent)
        transform.localPosition += new Vector3(-horizontalMovement, 0, 0);

        // Check if rock moves past the left side of the background
        if (transform.localPosition.x < xBoundLeft - 50f)  // 50f buffer ensures it's fully offscreen
        {
            RespawnRock();
        }
    }

    private void RespawnRock()
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.x = xBoundRight + respawnOffset;  // Move just offscreen to the right
        transform.localPosition = newPosition;

        // Optional log
        // Debug.Log($"Rock respawned at {newPosition.x}");
    }
}