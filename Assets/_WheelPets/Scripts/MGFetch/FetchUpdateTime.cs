using UnityEngine;
using UnityEngine.Localization;
using TMPro;
using UnityEngine.UI;

public class FetchUpdateTime : MonoBehaviour
{
    [SerializeField] private LocalizedString timeText;
    [SerializeField] private TextMeshProUGUI textMeshProComp;
    [SerializeField] private Text uiTextComp;

    private float timer;

    public float Timer
    {
        get => timer;
        set
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
}
