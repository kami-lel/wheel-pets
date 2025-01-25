using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pausePrefab; // The prefab to display when paused
    private GameObject pauseInstance; // Instance of the pause prefab
    private bool isPaused = false; // Tracks whether the game is paused

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Display the pause prefab
            if (pausePrefab != null && pauseInstance == null)
            {
                pauseInstance = Instantiate(pausePrefab); // Instantiate the prefab
                Canvas mainCanvas = FindObjectOfType<Canvas>(); // Find the main Canvas in the scene
                if (mainCanvas != null)
                {
                    pauseInstance.transform.SetParent(mainCanvas.transform, false); // Set parent to Canvas
                }
                else
                {
                    Debug.LogError("Main Canvas not found. Make sure a Canvas exists in the scene.");
                }
            }

            Time.timeScale = 0; // Pause the game
        }
        else
        {
            // Remove the pause prefab
            if (pauseInstance != null)
            {
                Destroy(pauseInstance); // Destroy the pause prefab
            }

            Time.timeScale = 1; // Resume the game
        }
    }

    void Update()
    {
        // Toggle pause using the P key (optional, you can connect this to a button instead)
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }
}
