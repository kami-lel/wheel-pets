using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// TODO implement visual cue for find/not find dog (in addition to audio cue) for accessibility reason
// TODO use PauseOverlay to handle game start/pause/win/loss
// TODO add more instruction for how to play the game
// TODO add high score function
// FIXME common buttons: back, pause, etc. should share a uniform design language / placement across scenes

public class Hide_n_Seek : MonoBehaviour
{
    [SerializeField]
    private Button[] buttons; // Array of 4 buttons
    private int correctButtonIndex; // Index of the correct button

    [SerializeField]
    private GameObject petPrefab; // Reference to the pet prefab

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
    private AudioSource randomAudio; // Stores random audio to be played on button press

    private bool buttonCooldown = false; // Bool to check if button is on cooldown

    private int delayButtonPress = 4; // Int to delay button press

    [SerializeField]
    private Image[] strikeImages; // Array to hold strike images

    private int strikeCounter = 0; // Int to count # of strikes

    [SerializeField] private Button restartButton; // Holds restart button

    [SerializeField] private GameObject winText; // Stores win text display
    [SerializeField] private GameObject loseText; // Stores lose text display

    public PauseOverlay pauseOverlay;

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
        if (!buttonCooldown)
        {
            // Choose random search audio and play it for 2 seconds
            chooseRandomAudio();
            randomAudio.Play();
            randomAudio.SetScheduledEndTime(2 + AudioSettings.dspTime);

            // Check if the pressed button is the correct one
            if (buttonIndex == correctButtonIndex)
            {
            // Instantiate the pet prefab at the position of the correct button
            Vector3 buttonPosition = buttons[buttonIndex].transform.position;
            GameObject petInstance = Instantiate(
                petPrefab,
                buttonPosition,
                Quaternion.identity
            );

            // Set the scale of the pet prefab
            petInstance.transform.localScale = new Vector3(0.1f, 0.1f, 1f);

            // Move the pet prefab to the front of the scene
            petInstance.transform.position = new Vector3(
                petInstance.transform.position.x,
                petInstance.transform.position.y,
                -1f
            );

                // Play correct guess audio with delay
                StartCoroutine(PlayGuessSound(correctGuessAudio));
                Debug.Log("You search the area... You found your pet!");

                // Display restart button on win
                restartButton.gameObject.SetActive(true);

                // Display win text
                winText.gameObject.SetActive(true);

            // Increment the times hide and seek won stat
            PlayerData data = Data.GetPlayerData();
            data.timesHideNSeekWon++;
            Data.SavePlayerDataToFile();
            pauseOverlay.MinigameWin();
        }
            else
    {
                // Hide & disable the button
                buttons[buttonIndex].gameObject.SetActive(false);

                // Play incorrect guess audio with delay
                StartCoroutine(PlayGuessSound(incorrectGuessAudio));
                Debug.Log("You search the area but do not find your pet...");

                // Display strikes on screen with delay
                StartCoroutine(DisplayStrikes());
    }

            // Start button cooldown timer
            StartCoroutine(ResetButtonCooldown());
            buttonCooldown = true;
    }
    }

    public void BackButtonOnClick()
    {
        SceneChange.LoadSelector();
    }

    public void RestartButtonOnClick()
    {
        SceneChange.LoadHideAndSeek();
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
        // Delay guess audio by 3 seconds before playing it
        yield return new WaitForSeconds(delayGuess);
        guessSound.Play();
        }

    IEnumerator ResetButtonCooldown()
    {
        // Start button cooldown for 4 seconds
        yield return new WaitForSeconds(delayButtonPress);
        buttonCooldown = false;
    }

    IEnumerator DisplayStrikes()
    {
        // Delay display of strikes to match sfx
        yield return new WaitForSeconds(delayGuess);

        strikeImages[strikeCounter].gameObject.SetActive(true);
        strikeCounter += 1;
        Debug.Log("Current strike count: " + strikeCounter);

        // If there are 3 strikes, display restart button
        if (strikeCounter == 3)
        {
            restartButton.gameObject.SetActive(true);

            // Display lose text
            loseText.gameObject.SetActive(true);
        }
        }

    void chooseRandomAudio()
        {
        // Choose random search/footstep audio and assign it to randomAudio
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

    void DisplayInstructions()
    {

    }
}
