using UnityEngine;
using UnityEngine.Localization.Settings;

// todo beautify reset data pop up
// todo beautify adopt a pet pop up
public class OptionsSceneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject adoptAPetPopUp;

    [SerializeField]
    private GameObject resetDataPopUp;

    public void OnClickBackButon()
    {
        SceneChange.LoadTitle();
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

    public void OnClickFactorResetButton()
    {
        resetDataPopUp.SetActive(true);
    }

    private void Start()
    {
        PlayerData playerData = Data.GetPlayerData();

        // 1st time game is launched, adoption process
        if (playerData.hasAdoptPet)
        {
            adoptAPetPopUp.SetActive(false);
        }
        else
        {
            playerData.hasAdoptPet = true;
            adoptAPetPopUp.SetActive(true);
        }
    }

    private void SetLocale(string localeCode)
    {
        var selectedLocale =
            LocalizationSettings.AvailableLocales.Locales.Find(locale =>
                locale.Identifier.Code == localeCode
            );
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
