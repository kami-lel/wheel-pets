using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// todo add best score system: fastest time to find the pet

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
    private int delayGuess = 2; // Int to delay guess sound
    private AudioSource randomAudio; // Stores random audio to be played on button press

    private bool buttonCooldown = false; // Bool to check if button is on cooldown

    private int delayButtonPress = 3; // Int to delay button press

    [SerializeField]
    private Image[] strikeImages; // Array to hold strike images

    private int strikeCounter = 0; // Int to count # of strikes

    [SerializeField]
    private Button restartButton; // Holds restart button

    [SerializeField]
    private GameObject winText; // Stores win text display

    [SerializeField]
    private GameObject loseText; // Stores lose text display

    public PauseOverlay pauseOverlay;

    public Image searchCompletion; // Used to display and track completion of search bar

    public GameObject searchBar; // Game object that holds search bar object

    public bool displaySearchBar = false; // Hold state of search bar display

    public float searchProgress = 0.0f; // Used to increment search bar completion

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

    void Update()
    {
        // Fill up the search bar in 1 second (increment of 10% per 0.1 sec)
        if (displaySearchBar == true)
        {
            if (searchProgress > 0.1)
            {
                searchCompletion.fillAmount += 0.1f;
                searchProgress = 0;
            }

            searchProgress += UnityEngine.Time.deltaTime;

            // Hide search bar if its completed
            if (searchCompletion.fillAmount == 1)
            {
                StartCoroutine(HideSearchBar());
            }
        }
    }
    void AssignCorrectButton()
    {
        // Randomly choose the correct button index
        correctButtonIndex = Random.Range(0, buttons.Length);
    }

    void OnButtonPressed(int buttonIndex)
    {
        // Allow button interaction if cooldown is not active
        if (!buttonCooldown)
        {
            // Move the search bar's position to the position of the button that's pressed
            searchBar.transform.position = new Vector3(
            buttons[buttonIndex].transform.position.x, 
            buttons[buttonIndex].transform.position.y, 
            buttons[buttonIndex].transform.position.z);

            // Display search bar and begin animation in Update()
            searchBar.gameObject.SetActive(true);
            displaySearchBar = true;

            if (buttonIndex != correctButtonIndex)
            {
                // Choose random search audio and play it for 1 second
                chooseRandomAudio();
                randomAudio.Play();
                randomAudio.SetScheduledEndTime(1 + AudioSettings.dspTime);
            }

            // Check if the pressed button is the correct one
            if (buttonIndex == correctButtonIndex)
            {
                buttons[buttonIndex].gameObject.SetActive(false);
                StartCoroutine(PlayCorrectGuessWithDelay());        
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
        // Delay guess audio by 2 seconds before playing it
        yield return new WaitForSeconds(delayGuess);
        guessSound.Play();
    }

    IEnumerator ResetButtonCooldown()
    {
        // Start button cooldown for 3 seconds
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
            RemoveStrikes();
            pauseOverlay.MinigameLost();
        }
    }

    IEnumerator HideSearchBar()
    {
        //Hide search bar 0.2 seconds after completion and reset its state
        yield return new WaitForSeconds(0.2f);
        searchBar.gameObject.SetActive(false); 
        searchCompletion.fillAmount = 0;
        displaySearchBar = false;
    }

    void RemoveStrikes()
    {
        for (int i = 0; i < 3; i++)
        {
            strikeImages[i].gameObject.SetActive(false);
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

IEnumerator PlayCorrectGuessWithDelay()
{
    // Choose random search audio and play it for 1 second
    chooseRandomAudio(); 
    randomAudio.Play();
    randomAudio.SetScheduledEndTime(AudioSettings.dspTime + 1); 

    yield return new WaitForSeconds(2); // Wait for search sound to play 

    correctGuessAudio.Play(); // Play the correct guess sound after search sound finishes
    Debug.Log("You search the area... You found your pet!");

    // Instantiate the pet prefab at the position of the correct button
    Vector3 buttonPosition = buttons[correctButtonIndex].transform.position;
    GameObject petInstance = Instantiate(petPrefab, buttonPosition, Quaternion.identity);

    // Set the scale of the pet prefab
    petInstance.transform.localScale = new Vector3(0.1f, 0.1f, 1f);

    // Move the pet prefab to the front of the scene
    petInstance.transform.position = new Vector3(
        petInstance.transform.position.x,
        petInstance.transform.position.y,
        -1f
    );

    // Remove strikes from screen and display win overlay
    RemoveStrikes();

    Data.GetPlayerData().statHide.RecordWin(0f);
    pauseOverlay.MinigameWin();
}

}