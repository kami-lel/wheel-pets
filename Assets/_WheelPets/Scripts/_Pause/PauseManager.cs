using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Button backButton; // Reference to the Back button
    [SerializeField] private Button exitButton; // Reference to the Exit button

    void Start()
    {
        Debug.Log("test");

        // Hook up the Back Button's OnClick event
        if (backButton != null)
        {
            Debug.Log("Back Button assigned successfully.");
            backButton.onClick.AddListener(() => {
                Debug.Log("Back Button clicked.");
                ToggleOffPause();
                Debug.Log("ToggleOffPause method executed.");
            });
        }
        else
        {
            Debug.LogError("Back Button is not assigned in the Inspector.");
        }

        // Hook up the Exit Button's OnClick event
        if (exitButton != null)
        {
            Debug.Log("Exit Button assigned successfully.");
            exitButton.onClick.AddListener(ReturnToPetGameScene);
        }
        else
        {
            Debug.LogError("Exit Button is not assigned in the Inspector.");
        }
    }

    public void ToggleOffPause()
    {

        Debug.Log("ToggleOffPause called.");
        if (PauseButton.pauseInstance != null)
        {
            Debug.Log("Destroying pauseInstance.");
            Destroy(PauseButton.pauseInstance);
            PauseButton.pauseInstance = null; // Clear the static instance
        }
        else
        {
            Debug.LogWarning("No pause instance to destroy.");
        }

        // Resume the game
        Time.timeScale = 1;
        Debug.Log("Game resumed (Time.timeScale = 1).");
    }

    private void ReturnToPetGameScene()
    {
        Debug.Log("Returning to PetGameScene...");
        Time.timeScale = 1; // Ensure the game is not paused when switching scenes
        SceneManager.LoadScene("PetGameScene"); // Load the PetGameScene
    }
}
