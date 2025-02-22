using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FetchScript : MonoBehaviour
{
    public GameObject timingBar;
    public GameObject line;
    public GameObject checkArea;
    public GameObject readyText;
    public GameObject goText;
    public GameObject gameOverText;
    public GameObject playAgainButton;
    public Text scoreText;
    public Text timerText;
    public float initialSpeed = 2.0f;
    public float speedIncrement = 0.5f;
    public GameObject ballPrefab;
    public Transform ballSpawnPoint;
    public Transform dogTransform;
    public Vector3 dogPositionOffset;

    private float currentSpeed;
    private bool isMovingRight = true;
    private bool gameActive = false;
    private int score = 0;
    private int highScore = 0;
    private float timer = 5.0f; // Initialize the timer to 5 seconds

    private int timingBarLength = 100;
    public int lineLength = 10;
    public int checkAreaLength = 20;
    private float linePosition = 0f;
    private int checkAreaPosition = 0;

    private List<GameObject> activeBalls = new List<GameObject>(); // List to track active balls

    void Start()
    {
        currentSpeed = initialSpeed;
        ResetLine();
        PositionCheckArea();
        StartCoroutine(StartGameRoutine());

        // Fetch the high score from PlayerData
        highScore = Data.GetPlayerData().fetchHighScore;
        UpdateScoreText();
        UpdateTimerText(); // Update the timer text
    }

    void Update()
    {
        if (gameActive)
        {
            MoveLine();
            if (Input.GetMouseButtonDown(0))
            {
                CheckHit();
            }

            // Update the timer
            timer -= Time.deltaTime;
            UpdateTimerText();

            if (timer <= 0)
            {
                // Game over
                gameActive = false;
                ShowGameOverText();
                Debug.Log("Game Over! Timer reached 0.");

                // Update the high score if the current score is higher
                if (score > highScore)
                {
                    highScore = score;
                    Data.GetPlayerData().fetchHighScore = highScore;
                }
            }
        }
    }

    void MoveLine()
    {
        float step = currentSpeed * Time.deltaTime * timingBarLength;
        if (isMovingRight)
        {
            linePosition += step;
            if (linePosition >= timingBarLength - lineLength)
            {
                linePosition = timingBarLength - lineLength;
                isMovingRight = false;
            }
        }
        else
        {
            linePosition -= step;
            if (linePosition <= 0)
            {
                linePosition = 0;
                isMovingRight = true;
            }
        }
        UpdateVisuals();
    }

    void CheckHit()
    {
        float lineStart = linePosition - lineLength / 2;
        float lineEnd = linePosition + lineLength / 2;
        float checkAreaStart = checkAreaPosition - checkAreaLength / 2;
        float checkAreaEnd = checkAreaPosition + checkAreaLength / 2;

        if (lineEnd >= checkAreaStart && lineStart <= checkAreaEnd)
        {
            // Successful hit
            score++;
            currentSpeed += speedIncrement;
            UpdateScoreText(); // Update the score text
            PositionCheckArea(); // Reposition the check area without resetting the line

            // Reset the timer to 5 seconds
            timer = 5.0f;
            UpdateTimerText();

            // Launch a ball towards the dog
            LaunchBall();
        }
        else
        {
            // Game over
            gameActive = false;
            ShowGameOverText();
            Debug.Log("Game Over! Final Score: " + score);

            // Update the high score if the current score is higher
            if (score > highScore)
            {
                highScore = score;
                Data.GetPlayerData().fetchHighScore = highScore;
            }
        }
    }

    void ResetLine()
    {
        linePosition = 0;
        isMovingRight = true;
        Debug.Log("Line reset to position: " + linePosition);
        UpdateVisuals();
    }

    void PositionCheckArea()
    {
        checkAreaPosition = Random.Range(0, timingBarLength - checkAreaLength);
        Debug.Log("Check area positioned at: " + checkAreaPosition);
        UpdateVisuals();
    }

    void UpdateVisuals()
    {
        float timingBarWidth = timingBar
            .GetComponent<RectTransform>()
            .rect.width;
        float unitWidth = timingBarWidth / timingBarLength;

        // Update the line's size and position
        line.GetComponent<RectTransform>().sizeDelta = new Vector2(
            lineLength * unitWidth,
            line.GetComponent<RectTransform>().sizeDelta.y
        );
        line.GetComponent<RectTransform>().anchoredPosition = new Vector2(
            linePosition * unitWidth - timingBarWidth / 2,
            line.GetComponent<RectTransform>().anchoredPosition.y
        );

        // Update the check area's size and position
        checkArea.GetComponent<RectTransform>().sizeDelta = new Vector2(
            checkAreaLength * unitWidth,
            checkArea.GetComponent<RectTransform>().sizeDelta.y
        );
        checkArea.GetComponent<RectTransform>().anchoredPosition = new Vector2(
            checkAreaPosition * unitWidth - timingBarWidth / 2,
            checkArea.GetComponent<RectTransform>().anchoredPosition.y
        );

        // Ensure the line is above the check area
        line.transform.SetAsLastSibling();

        Debug.Log(
            "Line position: "
                + line.GetComponent<RectTransform>().anchoredPosition
        );
        Debug.Log(
            "Check area position: "
                + checkArea.GetComponent<RectTransform>().anchoredPosition
        );
    }

    IEnumerator StartGameRoutine()
    {
        // Show ReadyText
        readyText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        readyText.SetActive(false);

        // Show GoText
        goText.SetActive(true);

        // Start the game
        gameActive = true;
    }

    void ShowGameOverText()
    {
        goText.SetActive(false);
        gameOverText.SetActive(true);
        playAgainButton.SetActive(true); // Enable the play again button
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "High Score: " + highScore + "\nScore: " + score;
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Ceil(timer).ToString();
        }
    }

    void LaunchBall()
    {
        if (
            ballPrefab != null
            && ballSpawnPoint != null
            && dogTransform != null
        )
        {
            GameObject ball = Instantiate(
                ballPrefab,
                ballSpawnPoint.position,
                Quaternion.identity
            );
            activeBalls.Add(ball); // Add the ball to the list of active balls
            StartCoroutine(MoveBall(ball));
        }
    }

    IEnumerator MoveBall(GameObject ball)
    {
        Vector3 startPosition = ball.transform.position;
        Vector3 endPosition = dogTransform.position + dogPositionOffset; // Apply the offset to the dog's position
        float duration = 1.0f; // Duration of the ball's flight
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            ball.transform.position = Vector3.Lerp(
                startPosition,
                endPosition,
                t
            );
            yield return null;
        }

        activeBalls.Remove(ball); // Remove the ball from the list of active balls
        Destroy(ball); // Destroy the ball when it reaches the dog
    }

    public void FreezeGame()
    {
        gameActive = false;
        StopAllCoroutines();

        // Destroy all active balls
        foreach (GameObject ball in activeBalls)
        {
            Destroy(ball);
        }
        activeBalls.Clear();
    }
}
