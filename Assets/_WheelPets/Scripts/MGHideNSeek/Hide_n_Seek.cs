using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// bug replace static pet with PetPrebab
public class Hide_n_Seek : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons; // Array of 4 buttons
    private int correctButtonIndex; // Index of the correct button

    [SerializeField]
    private Sprite petSprite;

    [SerializeField]
    AudioSource backgroundMusic; // Audio source for background music

    [SerializeField]
    AudioSource footstepAudio; // Audio source for footstep sfx

    [SerializeField]
    AudioSource correctGuessAudio; // Audio source for correct guess

    [SerializeField]
    AudioSource incorrectGuessAudio; // Audio source for incorrect guess

    [SerializeField]
    AudioSource searching1Audio; // Audio source for searching1 sfx

    [SerializeField]
    AudioSource searching2Audio; // Audio source for searching2 sfx
    private int delayGuess = 3; // Int to delay guess sound
    private AudioSource randomAudio;

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
        // Choose random search audio and play it for 2 seconds
        chooseRandomAudio();
        randomAudio.Play();
        randomAudio.SetScheduledEndTime(2 + AudioSettings.dspTime);

        // Check if the pressed button is the correct one
        if (buttonIndex == correctButtonIndex)
        {
            // Replace button image with petSprite
            buttons[buttonIndex].image.sprite = petSprite;

            // Play correct guess audio with delay
            StartCoroutine(PlayGuessSound(correctGuessAudio));
            Debug.Log("You search the area... You found your pet!");
        }
        else
        {
            // Hide & disable the button
            buttons[buttonIndex].gameObject.SetActive(false);

            // Play incorrect guess audio with delay
            StartCoroutine(PlayGuessSound(incorrectGuessAudio));
            Debug.Log($"You search the area but do not find your pet...");
        }
    }

    public void BackButtonOnClick()
    {
        SceneChange.LoadSelector();
    }

    void PlayBackgroundMusic()
    {
        backgroundMusic.Play();
    }

    void PauseBackgroundMusic()
    {
        backgroundMusic.Pause();
    }

    IEnumerator PlayGuessSound(AudioSource guessSound)
    {
        //delay guess audio by 3 seconds before playing it
        yield return new WaitForSeconds(delayGuess);
        guessSound.Play();
    }

    void chooseRandomAudio()
    {
        //choose random search/footstep audio and assign it to randomAudio
        int chooseAudio = Random.Range(1, 4);

        if (chooseAudio == 1)
        {
            randomAudio = footstepAudio;
        }
        else if (chooseAudio == 2)
        {
            randomAudio = searching1Audio;
        }
        else
        {
            randomAudio = searching2Audio;
        }
    }
}
