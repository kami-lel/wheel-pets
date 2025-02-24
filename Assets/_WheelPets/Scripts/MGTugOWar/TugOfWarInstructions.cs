using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TugOfWarInstructions : MonoBehaviour
{
    public GameObject instructionsButton;
    public GameObject instructionsPage;
    public GameObject instructionsBackButton;
    public GameObject readyText;
    public GameObject tapText;
    public GameObject winText;
    public GameObject losesText;
    public GameObject backButton;
    public TugOfWarManager tugOfWarManager;

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
        if (tugOfWarManager != null)
        {
            tugOfWarManager.FreezeGame();
        }

        // Disable game UI elements
        if (readyText != null) readyText.SetActive(false);
        if (tapText != null) tapText.SetActive(false);
        if (winText != null) winText.SetActive(false);
        if (losesText != null) losesText.SetActive(false);
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
