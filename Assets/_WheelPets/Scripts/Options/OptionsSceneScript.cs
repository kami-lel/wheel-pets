using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

// todo beautify reset data pop up
// todo beautify adopt a pet pop up
// bug add button click sounds
// bug music / sfx slide is broken
public class OptionsSceneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject adoptAPetPopUp;

    [SerializeField]
    private GameObject resetDataPopUp;

    [SerializeField]
    private PetScript petPrefabObject;

    [SerializeField]
    private Slider dominantColorSlider;

    [SerializeField]
    private Slider secondaryColorSlider;

    [SerializeField]
    private TextMeshProUGUI petNameTextFieldPlaceholder;

    public void OnClickBackButon()
    {
        SceneChange.LoadTitle();
    }

    public void OnClickEnglishButton()
    {
        SetLocale("en");
        playerData.language = "en";
    }

    public void OnClickSpanishButton()
    {
        SetLocale("es");
        playerData.language = "es";
    }

    public void OnClickFrenchButton()
    {
        SetLocale("fr");
        playerData.language = "fr";
    }

    public void OnClickFactorResetButton()
    {
        resetDataPopUp.SetActive(true);
    }

    public void OnEndEditPetNameTextField(string value)
    {
        playerData.petData.name = value;
        if (Debug.isDebugBuild)
        {
            Debug.Log($"OptionsScene\tChange Pet Name:{value}");
        }
    }

    /// <summary>
    /// Handles the Puppy button click event. Sets the pet type to Dog.
    /// /// </summary>
    public void OnClickPuppyButton()
    {
        playerData.ChangeAnimalType(PlayerData.AnimalType.Dog);
        petPrefabObject.UpdateLook();
        ZeroSliderVisual();
        if (Debug.isDebugBuild)
        {
            Debug.Log("OptionsScene\tChange Animal to Dog");
        }
    }

    /// <summary>
    /// Handles the Kitten button click event. Sets the pet type to Cat.
    /// </summary>
    public void OnClickKittenButton()
    {
        playerData.ChangeAnimalType(PlayerData.AnimalType.Cat);
        petPrefabObject.UpdateLook();
        ZeroSliderVisual();

        if (Debug.isDebugBuild)
        {
            Debug.Log("OptionsScene\tChange Animal to Cat");
        }
    }

    /// <summary>
    /// Handles the Rabbit button click event. Sets the pet type to Rabbit.
    /// </summary>
    public void OnClickRabbitButton()
    {
        playerData.ChangeAnimalType(PlayerData.AnimalType.Rabbit);
        petPrefabObject.UpdateLook();
        ZeroSliderVisual();

        if (Debug.isDebugBuild)
        {
            Debug.Log("OptionsScene\tChange Animal to Rabbit");
        }
    }

    public void OnValueChangedDominantColorSlider(Single value)
    {
        playerData.petData.dominantColorHue = value;
        petPrefabObject.UpdateLook();
    }

    public void OnValueChangedSecondaryjColorSlider(Single value)
    {
        playerData.petData.secondaryColorHue = value;
        petPrefabObject.UpdateLook();
    }

    private PlayerData playerData;

    private void Start()
    {
        playerData = Data.GetPlayerData();

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

        // set up ui component initial values
        dominantColorSlider.value = playerData.petData.dominantColorHue;
        secondaryColorSlider.value = playerData.petData.secondaryColorHue;
        petNameTextFieldPlaceholder.text = playerData.petData.name;
    }

    private void ZeroSliderVisual()
    {
        dominantColorSlider.value = 0f;
        secondaryColorSlider.value = 0f;
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
