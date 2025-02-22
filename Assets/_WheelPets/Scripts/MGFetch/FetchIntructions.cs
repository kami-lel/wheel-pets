using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FetchInstructions : MonoBehaviour
{
    public GameObject instructionsButton;
    public GameObject instructionsPage;
    public GameObject instructionsBackButton;
    public GameObject readyText;
    public GameObject goText;
    public GameObject gameOverText;
    public GameObject backButton;
    public FetchScript fetchScript;

    void Start()
    {
        // Add button listeners
        if (instructionsButton != null)
        {
            instructionsButton.GetComponent<Button>().onClick.AddListener(OnInstructionsButtonClick);
        }
        if (instructionsBackButton != null)
        {
            instructionsBackButton.GetComponent<Button>().onClick.AddListener(OnInstructionsBackButtonClick);
        }
    }

    void OnInstructionsButtonClick()
    {
        // Freeze the game
        if (fetchScript != null)
        {
            fetchScript.FreezeGame();
        }

        // Disable game UI elements
        if (readyText != null) readyText.SetActive(false);
        if (goText != null) goText.SetActive(false);
        if (gameOverText != null) gameOverText.SetActive(false);
        if (backButton != null) backButton.SetActive(false);
        if (instructionsButton != null) instructionsButton.SetActive(false);

        // Enable instructions page
        if (instructionsPage != null) instructionsPage.SetActive(true);
        if (instructionsBackButton != null) instructionsBackButton.SetActive(true);
    }

    void OnInstructionsBackButtonClick()
    {
        // Restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
