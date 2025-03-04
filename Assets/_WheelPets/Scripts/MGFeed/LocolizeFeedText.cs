using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using TMPro;

public class LocalizedGameText : MonoBehaviour
{
    public LocalizeStringEvent wantTextEvent;
    public LocalizeStringEvent scoreTextEvent;
    public TMP_Text wantText;
    public TMP_Text scoreText;
    private int score;

    private void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    public void UpdateWantText(int foodIndex)
    {
        if (wantTextEvent != null)
        {
            wantTextEvent.StringReference.Arguments = new object[] { foodIndex + 1 };
            wantTextEvent.RefreshString();
        }
    }

    public void UpdateScoreText()
    {
        if (scoreTextEvent != null)
        {
            scoreTextEvent.StringReference.Arguments = new object[] { score };
            scoreTextEvent.RefreshString();
        }
    }

    public void IncrementScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }
}
