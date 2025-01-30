using UnityEngine;

public class FetchScript : MonoBehaviour
{
    public GameObject timingBar;
    public GameObject line;
    public GameObject checkArea;
    public float initialSpeed = 2.0f;
    public float speedIncrement = 0.5f;

    private float currentSpeed;
    private bool isMovingRight = true;
    private bool gameActive = true;
    private int score = 0;

    private int timingBarLength = 100;
    private int lineLength = 20;
    private int checkAreaLength = 30;
    private int linePosition = 0;
    private int checkAreaPosition = 0;

    void Start()
    {
        currentSpeed = initialSpeed;
        ResetLine();
        PositionCheckArea();
        UpdateVisuals();
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
            linePosition += (int)step;
            if (linePosition >= timingBarLength - lineLength)
            {
                linePosition = timingBarLength - lineLength;
                isMovingRight = false;
            }
        }
        else
        {
            linePosition -= (int)step;
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
        if (linePosition >= checkAreaPosition && linePosition + lineLength <= checkAreaPosition + checkAreaLength)
        {
            // Successful hit
            score++;
            currentSpeed += speedIncrement;
            ResetLine();
            PositionCheckArea();
        }
        else
        {
            // Game over
            gameActive = false;
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

        line.GetComponent<RectTransform>().sizeDelta = new Vector2(lineLength * unitWidth, line.GetComponent<RectTransform>().sizeDelta.y);
        line.GetComponent<RectTransform>().anchoredPosition = new Vector2(linePosition * unitWidth - timingBarWidth / 2, line.GetComponent<RectTransform>().anchoredPosition.y);

        checkArea.GetComponent<RectTransform>().sizeDelta = new Vector2(checkAreaLength * unitWidth, checkArea.GetComponent<RectTransform>().sizeDelta.y);
        checkArea.GetComponent<RectTransform>().anchoredPosition = new Vector2(checkAreaPosition * unitWidth - timingBarWidth / 2, checkArea.GetComponent<RectTransform>().anchoredPosition.y);
    }
}