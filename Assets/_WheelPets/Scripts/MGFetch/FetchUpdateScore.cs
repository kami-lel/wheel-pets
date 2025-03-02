using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization;
using TMPro;
using UnityEngine.UI;
using System;

public class FetchUpdateScore : MonoBehaviour
{
    [SerializeField] private LocalizedString scoreText;
    [SerializeField] private TextMeshProUGUI textMeshProComp;
    [SerializeField] private Text uiTextComp;

    private int score;

    public int Score => score;

    private void OnEnable()
    {
        scoreText.Arguments = new object[] { score };
        scoreText.StringChanged += UpdateText;
    }

    private void OnDisable()
    {
        scoreText.StringChanged -= UpdateText;
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

    public void IncreaseScore()
    {
        score++;
        scoreText.Arguments[0] = score;
        scoreText.RefreshString();
    }
}
