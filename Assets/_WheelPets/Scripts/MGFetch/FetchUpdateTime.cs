using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FetchUpdateTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProComp;
    [SerializeField] private Text uiTextComp;

    private float timer = 5.0f; // Initialize the timer to 5 seconds

    public float Timer
    {
        get => timer;
        private set
        {
            timer = value;
            UpdateTimeText();
        }
    }

    private void UpdateTimeText()
    {
        string timeText = GetLocalizedTimeText(Mathf.Ceil(timer));
        if (textMeshProComp != null)
        {
            textMeshProComp.text = timeText;
        }
        else if (uiTextComp != null)
        {
            uiTextComp.text = timeText;
        }
    }

    private string GetLocalizedTimeText(float time)
    {
        string language = Data.GetPlayerData().language;
        Debug.Log("Current Language: " + language); // Debug log to verify the language
        switch (language)
        {
            case "fr":
                return $"Temps: {time}";
            case "es":
                return $"Tiempo: {time}";
            default:
                return $"Time: {time}";
        }
    }

    public void ResetTimer()
    {
        Timer = 5.0f;
    }

    public void StopTimer()
    {
        Timer = 0.0f;
    }

    public void ChangeTimer(float seconds)
    {
        Timer += seconds;
    }
}