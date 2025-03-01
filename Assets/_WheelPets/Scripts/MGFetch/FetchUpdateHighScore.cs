using UnityEngine;
using UnityEngine.Localization;
using TMPro;
using UnityEngine.UI;

public class FetchUpdateHighScore : MonoBehaviour
{
    [SerializeField] private LocalizedString highScoreText;
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

    private void OnEnable()
    {
        highScoreText.Arguments = new object[] { highScore };
        highScoreText.StringChanged += UpdateText;
    }

    private void OnDisable()
    {
        highScoreText.StringChanged -= UpdateText;
    }

    private void UpdateText(string value)
    {
        if (textMeshProComp != null)
        {
            textMeshProComp.text = value;
        }
        else if (uiTextComp != null)
        {
            uiTextComp.text = value;
        }
    }

    private void UpdateHighScoreText()
    {
        highScoreText.Arguments[0] = highScore;
        highScoreText.RefreshString();
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
