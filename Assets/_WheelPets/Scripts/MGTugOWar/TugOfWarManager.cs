using System.Collections;
using UnityEngine;

// BUG replace static pet with PetPrebab
// TODO add start/win/lose/restart function
// todo add more instruction for how to play the game
// todo add high score function
// todo Feels too easy to spam tap, Maybe make a restriction on tapping?
// fixme common buttons: back, pause, etc. should share an uniform design language / placement across scenes
// BUG pause is not working with click to play
public class TugOfWarManager : MonoBehaviour
{
    public GameObject ropeLine;
    public GameObject flag;
    public GameObject playerGoalLine;
    public GameObject petGoalLine;
    public float moveSpeed = .001f;
    public float tapMoveSpeed = .002f;
    public GameObject readyText;
    public GameObject tapText;
    public AudioSource cheeringSound;
    public AudioSource booingSound;
    public AudioSource BackgroundMusic;

    [SerializeField]
    private PauseOverlay pauseOverlay;

    private bool gameStarted = false;
    private bool gameWon = false;
    private bool gameLost = false;

    private Coroutine gameRoutine;

    void Start()
    {
        gameRoutine = StartCoroutine(StartGameRoutine());

        // Set the z position of the goal lines to be behind other objects
        if (playerGoalLine != null)
        {
            playerGoalLine.transform.position = new Vector3(
                playerGoalLine.transform.position.x,
                playerGoalLine.transform.position.y,
                1
            );
        }
        if (petGoalLine != null)
        {
            petGoalLine.transform.position = new Vector3(
                petGoalLine.transform.position.x,
                petGoalLine.transform.position.y,
                1
            );
        }

        BackgroundMusic.Play();
    }

    void Update()
    {
        if (gameStarted && !gameWon && !gameLost)
        {
            MoveRopeLine();
            CheckFlagGoalCollision();
        }
        else if (gameWon || gameLost)
        {
            FreezeRopeLine();
        }

        if (Input.GetMouseButtonDown(0)) // Detects mouse click or screen tap
        {
            if (gameStarted && !gameWon && !gameLost)
            {
                MoveRopeLineRight();
            }
        }
    }

    void MoveRopeLine()
    {
        if (ropeLine != null && gameStarted && !gameWon && !gameLost)
        {
            ropeLine.transform.Translate(
                Vector3.left * moveSpeed * Time.deltaTime
            );
        }
        else
        {
            Debug.Log(
                "MoveRopeLine - Conditions not met. gameStarted: "
                    + gameStarted
                    + ", gameWon: "
                    + gameWon
                    + ", gameLost: "
                    + gameLost
            );
        }
    }

    void MoveRopeLineRight()
    {
        if (ropeLine != null)
        {
            ropeLine.transform.Translate(Vector3.right * tapMoveSpeed);
        }
        else
        {
            Debug.LogWarning("ropeLine is not assigned");
        }
    }

    IEnumerator StartGameRoutine()
    {
        // Show ReadyText
        if (readyText != null)
        {
            readyText.SetActive(true);
        }

        // Wait for 3 seconds
        yield return new WaitForSeconds(3.0f);

        // Hide ReadyText
        if (readyText != null)
        {
            readyText.SetActive(false);
        }

        // Show TapText
        if (tapText != null)
        {
            tapText.SetActive(true);
        }

        // Start the game
        gameStarted = true;
        Debug.Log("Game started");
    }

    public void TriggerWinState()
    {
        // Stop the game
        gameStarted = false;
        gameWon = true;

        if (Debug.isDebugBuild)
        {
            Debug.Log(
                "TriggerWinState - Game Started: "
                    + gameStarted
                    + ", gameWon: "
                    + gameWon
            );
        }

        // Hide TapText
        if (tapText != null)
        {
            tapText.SetActive(false);
        }

        // Play cheering sound
        if (cheeringSound != null)
        {
            cheeringSound.Play();
        }

        // Freeze the RopeLine
        FreezeRopeLine();

        pauseOverlay.MinigameWin();
    }

    public void TriggerLoseState()
    {
        // Stop the game
        gameStarted = false;
        gameLost = true;

        if (Debug.isDebugBuild)
        {
            Debug.Log(
                "TriggerLoseState - Game Started: "
                    + gameStarted
                    + ", gameLost: "
                    + gameLost
            );
        }

        // Hide TapText
        if (tapText != null)
        {
            tapText.SetActive(false);
        }

        // Play booing sound
        if (booingSound != null)
        {
            booingSound.Play();
        }

        // FIXME alt implementation
        // Freeze the RopeLine
        FreezeRopeLine();

        pauseOverlay.MinigameLost();
    }

    void FreezeRopeLine()
    {
        if (ropeLine != null)
        {
            Rigidbody2D rb = ropeLine.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }

    void CheckFlagGoalCollision()
    {
        if (flag != null && playerGoalLine != null && petGoalLine != null)
        {
            if (
                flag.GetComponent<Collider2D>()
                    .IsTouching(playerGoalLine.GetComponent<Collider2D>())
            )
            {
                Debug.Log("Flag touched the player goal line");
                TriggerWinState();
            }
            else if (
                flag.GetComponent<Collider2D>()
                    .IsTouching(petGoalLine.GetComponent<Collider2D>())
            )
            {
                Debug.Log("Flag touched the pet goal line");
                TriggerLoseState();
            }
        }
    }

    public void FreezeGame()
    {
        gameStarted = false;
        if (gameRoutine != null)
        {
            StopCoroutine(gameRoutine);
        }
    }

    public bool IsGameStarted()
    {
        return gameStarted;
    }
}
