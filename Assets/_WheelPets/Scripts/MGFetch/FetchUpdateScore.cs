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
        string scoreText = $"Score: {score}";
        if (textMeshProComp != null)
        {
            textMeshProComp.text = scoreText;
        }
        else if (uiTextComp != null)
        {
            uiTextComp.text = scoreText;
        }
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }
}