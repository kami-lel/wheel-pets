using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AdoptionSceneScript : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField petNameField;

    [SerializeField]
    private Button puppyButton;

    [SerializeField]
    private Button kittenButton;

    [SerializeField]
    private Button rabbitButton;

    [SerializeField]
    private Slider dominantColorSlider;

    [SerializeField]
    private Slider secondaryColorSlider;

    [SerializeField]
    private Button saveButton;

    [SerializeField]
    private PetScript petObject;

    private PlayerData playerData;
    private PlayerData.PetData petData;

    void Start()
    {
        playerData = PlayerData.Data;
        petData = playerData.petData;

        // set up animal selection buttons
        puppyButton.onClick.AddListener(() =>
        {
            petData.animalType = 0;
            petObject.UpdateLook();
        });

        kittenButton.onClick.AddListener(() =>
        {
            petData.animalType = 1;
            petObject.UpdateLook();
        });

        rabbitButton.onClick.AddListener(() =>
        {
            petData.animalType = 2;
            petObject.UpdateLook();
        });

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

        // set up save button
        saveButton.onClick.AddListener(() =>
        {
            // todo add feedback
            if (petNameField.text != "")
            {
                petData.name = petNameField.text;
            }

            PlayerData.SaveToFile(); // fixme should save button save to file?
        });
    }

    void Update() { }

    private void OnApplicationQuit()
    {
        PlayerData.SaveToFile();
    }
}
