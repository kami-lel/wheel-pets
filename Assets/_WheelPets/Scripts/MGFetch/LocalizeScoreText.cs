using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class LocalizedScoreText : MonoBehaviour
{
    public LocalizeStringEvent localizeStringEvent;
    public Text scoreText;
    private int score;

    private void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    public void IncrementScore()
    {
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (localizeStringEvent != null)
        {
            localizeStringEvent.StringReference.Arguments = new object[] { score };
            localizeStringEvent.RefreshString();
        }
    }
}
