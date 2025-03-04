using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FetchUpdateHighScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProComp;
    [SerializeField] private Text uiTextComp;

    private int highScore;

    public int HighScore => highScore;

    private void Start()
    {
        // Fetch the high score from PlayerData
        PlayerData data = Data.GetPlayerData();
        if (data != null)
        {
            highScore = data.fetchHighScore;
            UpdateHighScoreText();
        }
        else
        {
            Debug.LogError("PlayerData is null");
        }
    }

    private void UpdateHighScoreText()
    {
        string highScoreText = $"High Score: {highScore}";
        if (textMeshProComp != null)
        {
            textMeshProComp.text = highScoreText;
        }
        else if (uiTextComp != null)
        {
            uiTextComp.text = highScoreText;
        }
    }

    public void UpdateHighScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerData data = Data.GetPlayerData();
            if (data != null)
            {
                data.fetchHighScore = highScore;
                Data.SavePlayerDataToFile();
                UpdateHighScoreText();
            }
            else
            {
                Debug.LogError("PlayerData is null");
            }
        }
    }
}