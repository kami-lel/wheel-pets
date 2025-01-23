using UnityEngine;
using System.Collections;

public class TugOfWarManager : MonoBehaviour
{
    public GameObject ropeLine;
    public float moveSpeed = 1.0f;
    public GameObject readyText;
    public GameObject tapText;
    public GameObject winText; // Add WinText

    private bool gameStarted = false;
    private bool gameWon = false; // Add gameWon flag

    void Start()
    {
        StartCoroutine(StartGameRoutine());
    }

    void Update()
    {
        if (gameStarted && !gameWon) // Check if the game is started and not won
        {
            MoveRopeLine();
        }
    }

    void MoveRopeLine()
    {
        Debug.Log("MoveRopeLine called");
        if (ropeLine != null && gameStarted && !gameWon) 
        {
            ropeLine.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
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
        if (ropeLine != null)
        {
            Rigidbody2D rb = ropeLine.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }

        Debug.Log("Update - Game Started: " + gameStarted + ", gameWon: " + gameWon);
    }

    public bool IsGameStarted()
    {
        return gameStarted;
    }
}
