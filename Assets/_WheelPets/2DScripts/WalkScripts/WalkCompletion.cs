using UnityEngine;
using TMPro;

public class WalkCompletion : WalkMovement
{
    [SerializeField] private TextMeshProUGUI completionText; // The TextMeshProUGUI to display the message

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

            // Disable arrow key functionality
            controlsEnabled = false;
        }
    }
}
