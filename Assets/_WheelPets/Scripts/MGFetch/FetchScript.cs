using UnityEngine;
using UnityEngine.UI; // Add this line to use the Text component
using System.Collections;

public class FetchScript : MonoBehaviour
{
    public GameObject timingBar;
    public GameObject line;
    public GameObject checkArea;
    public GameObject readyText;
    public GameObject goText;
    public GameObject gameOverText;
    public GameObject playAgainButton; // Add this line to declare the PlayAgainButton variable
    public Text scoreText; // Add this line to declare the ScoreText variable
    public float initialSpeed = 2.0f;
    public float speedIncrement = 0.5f;

    private float currentSpeed;
    private bool isMovingRight = true;
    private bool gameActive = false;
    private int score = 0;

    private int timingBarLength = 100;
    public int lineLength = 10;
    public int checkAreaLength = 20;
    private float linePosition = 0f;
    private int checkAreaPosition = 0;

    void Start()
    {
        currentSpeed = initialSpeed;
        ResetLine();
        PositionCheckArea();
        StartCoroutine(StartGameRoutine());
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
            ResetLine();
            PositionCheckArea();
        }
        else
        {
            // Game over
            gameActive = false;
            ShowGameOverText();
            Debug.Log("Game Over! Final Score: " + score);
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
        float timingBarWidth = timingBar.GetComponent<RectTransform>().rect.width;
        float unitWidth = timingBarWidth / timingBarLength;

        // Update the line's size and position
        line.GetComponent<RectTransform>().sizeDelta = new Vector2(lineLength * unitWidth, line.GetComponent<RectTransform>().sizeDelta.y);
        line.GetComponent<RectTransform>().anchoredPosition = new Vector2(linePosition * unitWidth - timingBarWidth / 2, line.GetComponent<RectTransform>().anchoredPosition.y);

        // Update the check area's size and position
        checkArea.GetComponent<RectTransform>().sizeDelta = new Vector2(checkAreaLength * unitWidth, checkArea.GetComponent<RectTransform>().sizeDelta.y);
        checkArea.GetComponent<RectTransform>().anchoredPosition = new Vector2(checkAreaPosition * unitWidth - timingBarWidth / 2, checkArea.GetComponent<RectTransform>().anchoredPosition.y);

        // Ensure the line is above the check area
        line.transform.SetAsLastSibling();

        Debug.Log("Line position: " + line.GetComponent<RectTransform>().anchoredPosition);
        Debug.Log("Check area position: " + checkArea.GetComponent<RectTransform>().anchoredPosition);
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
            scoreText.text = "Score: " + score;
        }
    }
}