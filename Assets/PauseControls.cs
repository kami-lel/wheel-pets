using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseControls : MonoBehaviour
{
    [SerializeField] private GameObject pausePrefab; // Reference to the pause prefab
    private GameObject pauseInstance; // Instance of the pause prefab
    private bool isPaused = false; // Tracks whether the game is paused

    [SerializeField] private Button backButton; // Reference to the Back button
    [SerializeField] private Button exitButton; // Reference to the Exit button

    void Start()
    {
        // Hook up the Back Button's OnClick event
        if (backButton != null)
        {
            backButton.onClick.AddListener(HandleBackButton);
        }
        else
        {
            Debug.LogError("Back Button is not assigned in the Inspector.");
        }

        // Hook up the Exit Button's OnClick event
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(HandleExitButton);
        }
        else
        {
            Debug.LogError("Exit Button is not assigned in the Inspector.");
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
                pauseInstance = null; // Clear reference
            }

            Time.timeScale = 1; // Resume the game
        }
    }

    private void HandleBackButton()
    {
        // Use TogglePause to unpause the game and remove the pause prefab
        if (isPaused)
        {
            TogglePause();
        }
    }

    private void HandleExitButton()
    {
        // Resume the game before switching scenes
        Time.timeScale = 1;
        SceneManager.LoadScene("PetGameScene"); // Replace "PetGame" with the actual scene name
    }
}
