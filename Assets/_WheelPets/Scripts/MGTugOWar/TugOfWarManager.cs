using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// BUG replace static pet with PetPrebab
// TODO add start button
// todo add more instruction for how to play the game
// todo add high score function
// todo Feels too easy to spam tap, Maybe make a restriction on tapping?
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
    public GameObject winText;
    public GameObject losesText;
    public AudioSource cheeringSound;
    public AudioSource booingSound;
    public AudioSource BackgroundMusic;

    private bool gameStarted = false;
    private bool gameWon = false;
    private bool gameLost = false;

    private TugOfWarSceneScript sceneScript;
    private Coroutine gameRoutine;

    void Start()
    {
        gameRoutine = StartCoroutine(StartGameRoutine());

        // Get reference to the TugOfWarSceneScript
        sceneScript = FindFirstObjectByType<TugOfWarSceneScript>();

        // Set the z position of the goal lines to be behind other objects
        if (playerGoalLine != null)
        {
            playerGoalLine.transform.position = new Vector3(playerGoalLine.transform.position.x, playerGoalLine.transform.position.y, 1);
        }
        if (petGoalLine != null)
        {
            petGoalLine.transform.position = new Vector3(petGoalLine.transform.position.x, petGoalLine.transform.position.y, 1);
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
            ropeLine.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
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
        yield return new WaitForSeconds(2.0f);

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
        Debug.Log("Win state triggered!");

        // Stop the game
        gameStarted = false;
        gameWon = true;

        // Hide TapText
        if (tapText != null)
        {
            tapText.SetActive(false);
        }

        // Show WinText
        if (winText != null)
        {
            winText.SetActive(true);
        }

        // Play cheering sound
        if (cheeringSound != null)
        {
            cheeringSound.Play();
        }

        // Freeze the RopeLine
        FreezeRopeLine();

        // Show Play Again Button after 2 seconds
        if (sceneScript != null)
        {
            sceneScript.ShowPlayAgainButton();
        }

        Debug.Log(
            "TriggerWinState - Game Started: "
                + gameStarted
                + ", gameWon: "
                + gameWon
        );
    }

    public void TriggerLoseState()
    {
        Debug.Log("Lose state triggered!");

        // Stop the game
        gameStarted = false;
        gameLost = true;

        // Hide TapText
        if (tapText != null)
        {
            tapText.SetActive(false);
        }

        // Show LosesText
        if (losesText != null)
        {
            losesText.SetActive(true);
        }

        // Play booing sound
        if (booingSound != null)
        {
            booingSound.Play();
        }

        // Freeze the RopeLine
        FreezeRopeLine();

        // Show Play Again Button after 2 seconds
        if (sceneScript != null)
        {
            sceneScript.ShowPlayAgainButton();
        }

        Debug.Log(
            "TriggerLoseState - Game Started: "
                + gameStarted
                + ", gameLost: "
                + gameLost
        );
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
