using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hide_n_Seek : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons; // Array of 4 buttons
    private int correctButtonIndex; // Index of the correct button
    [SerializeField] AudioSource backgroundMusic; // Audio source for background music

    void Start()
    {
        // Ensure there are 4 buttons assigned
        if (buttons.Length != 4)
        {
            Debug.LogError("You must assign exactly 4 buttons.");
            return;
        }

        // Assign click listeners to all buttons
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Capture the current index
            buttons[i].onClick.AddListener(() => OnButtonPressed(index));
        }

        // Randomly choose the initial correct button
        // Randomly choose the initial correct button
        AssignCorrectButton();

        // Play the background music on start
        PlayBackgroundMusic();

    }

    void AssignCorrectButton()
    {
        // Randomly choose the correct button index
        correctButtonIndex = Random.Range(0, buttons.Length);
    }

    void OnButtonPressed(int buttonIndex)
    {
        // Check if the pressed button is the correct one
        if (buttonIndex == correctButtonIndex)
        {
            Debug.Log("You search the area... You found your pet!");
        }
        else
        {
            Debug.Log($"You search the area but do not find your pet...");
        }
    }

    public void BackButtonOnClick()
    {
        SceneManager.LoadScene("_SelectorScene");
    }

    void PlayBackgroundMusic()
    {
        backgroundMusic.Play();
    }

    void PauseBackgroundMusic()
    {
        backgroundMusic.Pause();
    }
}
