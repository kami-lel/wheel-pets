using UnityEngine;
using UnityEngine.Localization;
using TMPro;
using UnityEngine.UI;

public class FetchUpdateTime : MonoBehaviour
{
    [SerializeField] private LocalizedString timeText;
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

    private void OnEnable()
    {
        timeText.Arguments = new object[] { Mathf.Ceil(timer) };
        timeText.StringChanged += UpdateText;
    }

    private void OnDisable()
    {
        timeText.StringChanged -= UpdateText;
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

    private void UpdateTimeText()
    {
        timeText.Arguments[0] = Mathf.Ceil(timer);
        timeText.RefreshString();
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
