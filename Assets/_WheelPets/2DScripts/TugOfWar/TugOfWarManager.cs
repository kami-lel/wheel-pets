using UnityEngine;
using System.Collections;

public class TugOfWarManager : MonoBehaviour
{
    public GameObject ropeLine;
    public GameObject flag; // Add flag variable
    public GameObject goalLine; // Add goalLine variable
    public float moveSpeed = 1.0f;
    public float tapMoveSpeed = 2.0f;
    public GameObject readyText;
    public GameObject tapText;
    public GameObject winText;

    private bool gameStarted = false;
    private bool gameWon = false;

    void Start()
    {
        StartCoroutine(StartGameRoutine());
    }

    void Update()
    {
        if (gameStarted && !gameWon) // Check if the game is started and not won
        {
            MoveRopeLine();
            CheckFlagGoalCollision(); // Check for collision between flag and goal line
        }
        else if (gameWon) // Check if the game is won
        {
            FreezeRopeLine();
        }

        if (Input.GetMouseButtonDown(0)) // Detects mouse click or screen tap
        {
            if (gameStarted && !gameWon)
            {
                MoveRopeLineLeft();
            }
        }
    }

    void MoveRopeLine()
    {
        if (ropeLine != null && gameStarted && !gameWon) 
        {
            ropeLine.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log("MoveRopeLine - Conditions not met. gameStarted: " + gameStarted + ", gameWon: " + gameWon);
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
        gameWon = true; // Set gameWon to true

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

        // Freeze the RopeLine
        FreezeRopeLine();

        Debug.Log("TriggerWinState - Game Started: " + gameStarted + ", gameWon: " + gameWon);
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

    public bool IsGameStarted()
    {
        return gameStarted;
    }
}
