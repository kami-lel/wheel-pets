using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FetchUpdateScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProComp;
    [SerializeField] private Text uiTextComp;

    private int score;

    public int Score => score;

    private void UpdateScoreText()
    {
        string scoreText = GetLocalizedScoreText(score);
        if (textMeshProComp != null)
        {
            textMeshProComp.text = scoreText;
        }
        else if (uiTextComp != null)
        {
            uiTextComp.text = scoreText;
        }
    }

    private string GetLocalizedScoreText(int score)
    {
        string language = Data.GetPlayerData().language;
        Debug.Log("Current Language: " + language); // Debug log to verify the language
        switch (language)
        {
            case "fr":
                return $"Score: {score}";
            case "es":
                return $"Puntuación: {score}";
            default:
                return $"Score: {score}";
        }
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }
}