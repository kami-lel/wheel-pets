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
    public int lineLength = 10;
    public int checkAreaLength = 20;
    private float linePosition = 0f;
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
}