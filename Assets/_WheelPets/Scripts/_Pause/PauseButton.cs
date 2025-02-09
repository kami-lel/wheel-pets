using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pausePrefab; // Reference to the pause prefab
    public static GameObject pauseInstance; // Static instance of the pause prefab

    void Start()
    {
        // Ensure the game is running normally at the start
        Time.timeScale = 1;
        Debug.Log("Game started with Time.timeScale = 1.");
    }

    public void PauseGame()
    {
        Debug.Log("PauseGame called.");

        if (pausePrefab != null)
        {
            if (pauseInstance == null)
            {
                Debug.Log("Attempting to instantiate pausePrefab.");

                // Display the pause prefab
                pauseInstance = Instantiate(pausePrefab);

                Canvas mainCanvas = FindObjectOfType<Canvas>();
                if (mainCanvas != null)
                {
                    pauseInstance.transform.SetParent(mainCanvas.transform, false);
                    Debug.Log("pauseInstance set as a child of the main canvas.");
                }
                else
                {
                    Debug.LogError("Main Canvas not found. Make sure a Canvas exists in the scene.");
                }
            }
            else
            {
                Debug.LogWarning("Pause instance already exists. No new instance will be created.");
            }
        }
        else
        {
            Debug.LogError("pausePrefab is not assigned in the Inspector.");
        }

        // Pause the game
        Time.timeScale = 0;
        Debug.Log("Game paused (Time.timeScale = 0).");
    }
}
