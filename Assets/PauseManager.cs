using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePrefab; // Reference to the pause prefab
    [SerializeField] private Button backButton; // Reference to the Back button
    private GameObject pauseInstance; // Instance of the pause prefab
    private bool isPaused = false; // Tracks whether the game is paused

    void Start()
    {
        // Hook up the Back Button's OnClick event
        if (backButton != null)
        {
            backButton.onClick.AddListener(ToggleOffPause);
        }
        else
        {
            Debug.LogError("Back Button is not assigned in the Inspector.");
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Display the pause prefab
            if (pausePrefab != null && pauseInstance == null)
            {
                pauseInstance = Instantiate(pausePrefab);
                Canvas mainCanvas = FindObjectOfType<Canvas>();
                if (mainCanvas != null)
                {
                    pauseInstance.transform.SetParent(mainCanvas.transform, false);
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
            ToggleOffPause(); // Toggle off pause when the game resumes
        }
    }

    public void ToggleOffPause()
    {
        if (pauseInstance != null)
        {
            Destroy(pauseInstance); // Destroy the pause prefab
            pauseInstance = null; // Clear the instance reference
        }

        isPaused = false; // Update the pause state
        Time.timeScale = 1; // Resume the game
    }
}
