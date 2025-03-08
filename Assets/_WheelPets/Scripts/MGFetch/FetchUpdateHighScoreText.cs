using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FetchUpdateHighScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProComp;
    [SerializeField] private Text uiTextComp;

    private void Start()
    {
        UpdateHighScoreText();
    }

    public void UpdateHighScoreText() // Changed from private to public
    {
        int highScore = Data.GetPlayerData().fetchHighScore;
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
}
