using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class OptionsSceneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject reAdoptPopUp;

    [SerializeField]
    private GameObject resetDataPopUp;

    // todo connect more buttons, etc. & combine w/ other code

    public void OnClickBackButon()
    {
        SceneChange.LoadTitle();
    }

    public void OnClickSaveButton()
    {
        // Fixme is saving button even neccessary?
        Debug.LogWarning("save button pushed, no effect yet");
    }

    public void OnClickEnglishButton()
    {
        SetLocale("en");
    }

    public void OnClickSpanishButton()
    {
        SetLocale("es");
    }

    public void OnClickFrenchButton()
    {
        SetLocale("fr");
    }

    public void OnClickReAdoptButton()
    {
        reAdoptPopUp.SetActive(true);
    }

    public void OnClickFactorResetButton()
    {
        resetDataPopUp.SetActive(true);
    }

    private void SetLocale(string localeCode)
    {
        var selectedLocale = LocalizationSettings.AvailableLocales.Locales.Find(locale => locale.Identifier.Code == localeCode);
        if (selectedLocale != null)
        {
            LocalizationSettings.SelectedLocale = selectedLocale;
            Debug.Log($"Locale set to {localeCode}");
        }
        else
        {
            Debug.LogWarning($"Locale {localeCode} not found");
        }
    }
}
