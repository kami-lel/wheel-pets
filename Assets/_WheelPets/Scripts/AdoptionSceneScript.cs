using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// todo only "save" button confirms pet look change
public class AdoptionSceneScript : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField petNameField;

    [SerializeField]
    private Slider dominantColorSlider;

    [SerializeField]
    private Slider secondaryColorSlider;

    [SerializeField]
    private PetScript petObject;

    private PlayerData playerData;
    private PlayerData.PetData petData;

    private void Start()
    {
        playerData = Data.GetPlayerData();
        petData = playerData.petData;

        // set up sliders values
        dominantColorSlider.value = petData.dominantColorHue;
        secondaryColorSlider.value = petData.secondaryColorHue;

        // set up sliders event listenr
        dominantColorSlider.onValueChanged.AddListener(
            (value) =>
            {
                petData.dominantColorHue = value;
                petObject.UpdateLook();
            }
        );
        secondaryColorSlider.onValueChanged.AddListener(
            (value) =>
            {
                petData.secondaryColorHue = value;
                petObject.UpdateLook();
            }
        );
    }

    public void PuppyButtonOnClick()
    {
        petData.animalType = 0;
        petObject.UpdateLook();
    }

    public void KittenButtonOnClick()
    {
        petData.animalType = 1;
        petObject.UpdateLook();
    }

    public void RabbitButtonOnClick()
    {
        petData.animalType = 2;
        petObject.UpdateLook();
    }

    public void SaveButtonOnClick()
    {
        // todo add feedback
        if (petNameField.text != "")
        {
            petData.name = petNameField.text;
        }
    }

    public void BackButtonOnClick()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    private void OnApplicationQuit()
    {
        Data.SavePlayerDataToFile();
    }
}
