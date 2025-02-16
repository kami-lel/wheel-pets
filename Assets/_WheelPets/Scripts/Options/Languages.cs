using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class LanguageManager : MonoBehaviour
{
    public static LanguageManager Instance;

    [SerializeField] private GameObject englishButton;
    [SerializeField] private GameObject frenchButton;
    [SerializeField] private GameObject spanishButton;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Load the saved language setting
        LoadLanguage();
    }

    public void SetLanguage(string localeIdentifier)
    {
        Locale locale = LocalizationSettings.AvailableLocales.GetLocale(localeIdentifier);
        LocalizationSettings.SelectedLocale = locale;

        // Save the selected language
        Data.GetPlayerData().language = localeIdentifier;
        Data.SavePlayerDataToFile();
    }

    private void LoadLanguage()
    {
        string savedLanguage = Data.GetPlayerData().language;
        SetLanguage(savedLanguage);
    }
}
