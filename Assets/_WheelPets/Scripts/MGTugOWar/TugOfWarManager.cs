using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TugOfWarManager : MonoBehaviour
{
    public GameObject ropeLine;
    public GameObject flag;
    public GameObject goalLine;
    public GameObject player;
    public float moveSpeed = 1.0f;
    public float tapMoveSpeed = 2.0f;
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

    void Start()
    {
        StartCoroutine(StartGameRoutine());

        // Get reference to the TugOfWarSceneScript
        sceneScript = FindObjectOfType<TugOfWarSceneScript>();

        BackgroundMusic.Play();
    }

    void Update()
    {
        if (gameStarted && !gameWon && !gameLost)
        {
            MoveRopeLine();
            CheckFlagGoalCollision();
            CheckPlayerGoalCollision();
        }
        else if (gameWon || gameLost)
        {
            FreezeRopeLine();
        }

        if (Input.GetMouseButtonDown(0)) // Detects mouse click or screen tap
        {
            if (gameStarted && !gameWon && !gameLost)
            {
                MoveRopeLineLeft();
            }
        }
    }

    void MoveRopeLine()
    {
        if (ropeLine != null && gameStarted && !gameWon && !gameLost)
        {
            ropeLine.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
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

    void MoveRopeLineLeft()
    {
        if (ropeLine != null)
        {
            ropeLine.transform.Translate(Vector3.left * tapMoveSpeed);
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

        Debug.Log("TriggerWinState - Game Started: " + gameStarted + ", gameWon: " + gameWon);
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

        Debug.Log("TriggerLoseState - Game Started: " + gameStarted + ", gameLost: " + gameLost);
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
        if (flag != null && goalLine != null)
        {
            if (flag.GetComponent<Collider2D>().IsTouching(goalLine.GetComponent<Collider2D>()))
            {
                Debug.Log("Flag touched the goal line");
                TriggerWinState();
            }
        }
    }

    void CheckPlayerGoalCollision()
    {
        if (player != null && goalLine != null)
        {
            if (player.GetComponent<Collider2D>().IsTouching(goalLine.GetComponent<Collider2D>()))
            {
                Debug.Log("Player touched the goal line");
                TriggerLoseState();
            }
        }
    }

    public bool IsGameStarted()
    {
        return gameStarted;
    }
}
