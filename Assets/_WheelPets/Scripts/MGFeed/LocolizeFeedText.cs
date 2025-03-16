using UnityEngine;
using TMPro;

public class LocalizedFeedText : MonoBehaviour
{
    public TMP_Text wantText; // Reference to the "I want..." text
    public TMP_Text foodsLeftText; // Reference to the "Foods Left" text

    public void UpdateWantText(int foodIndex)
    {
        if (wantText != null)
        {
            wantText.text = FeedLocalizationManager.Instance.GetTranslation("i_want_text", foodIndex + 1);
        }
    }

    public void UpdateFoodsLeftText(int score)
    {
        if (foodsLeftText != null)
        {
            foodsLeftText.text = FeedLocalizationManager.Instance.GetTranslation("foods_left_text", score);
        }
    }

    public void UpdateTexts(int foodIndex, int score)
    {
        UpdateWantText(foodIndex);
        UpdateFoodsLeftText(score);
    }
}