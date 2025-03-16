using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FetchUpdateHighScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProComp;
    [SerializeField] private Text uiTextComp;

    private string _currentLanguage;

    private void Start()
    {
        _currentLanguage = Data.GetPlayerData().language;
        UpdateHighScoreText();
    }

    private void Update()
    {
        // Check if the language has changed
        if (_currentLanguage != Data.GetPlayerData().language)
        {
            _currentLanguage = Data.GetPlayerData().language;
            UpdateHighScoreText();
        }
    }

    public void UpdateHighScoreText()
    {
        int highScore = Data.GetPlayerData().fetchHighScore;
        string highScoreText = GetLocalizedHighScoreText(highScore);

        if (textMeshProComp != null)
        {
            textMeshProComp.text = highScoreText;
        }
        else if (uiTextComp != null)
        {
            uiTextComp.text = highScoreText;
        }
    }

    private string GetLocalizedHighScoreText(int highScore)
    {
        string language = Data.GetPlayerData().language;
        Debug.Log("Current Language: " + language); // Debug log to verify the language
        switch (language)
        {
            case "fr":
                return $"Meilleur Score: {highScore}";
            case "es":
                return $"Puntuación Más Alta: {highScore}";
            default:
                return $"High Score: {highScore}";
        }
    }
}