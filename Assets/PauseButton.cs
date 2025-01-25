using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pausePrefab; // Reference to the pause prefab
    private GameObject pauseInstance; // Instance of the pause prefab
    private bool isPaused = false; // Tracks whether the game is paused

    void Start()
    {
    
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
            // Remove the pause prefab
            if (pauseInstance != null)
            {
                Destroy(pauseInstance);
                pauseInstance = null;
            }
            Time.timeScale = 1; // Resume the game
        }
    }
}
