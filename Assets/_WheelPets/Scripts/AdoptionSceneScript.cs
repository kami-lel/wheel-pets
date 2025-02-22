using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// TODO only "save" button confirms pet look change
// TODO make adoption scene part of game loop
public class AdoptionSceneScript : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField petNameField;

    [SerializeField]
    private Slider dominantColorSlider;

    [SerializeField]
    private Slider secondaryColorSlider;

    [SerializeField]
    private PetScript petPrefabObject;

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
                petPrefabObject.UpdateLook();
            }
        );
        secondaryColorSlider.onValueChanged.AddListener(
            (value) =>
            {
                petData.secondaryColorHue = value;
                petPrefabObject.UpdateLook();
            }
        );
    }

    /// <summary>
    /// Handles the Puppy button click event. Sets the pet type to Dog
    /// </summary>
    public void PuppyButtonOnClick()
    {
        petData.animalType = PlayerData.AnimalType.Dog;
        petPrefabObject.UpdateLook();
    }

    /// <summary>
    /// Handles the Kitten button click event. Sets the pet type to Cat
    /// </summary>
    public void KittenButtonOnClick()
    {
        petData.animalType = PlayerData.AnimalType.Cat;
        petPrefabObject.UpdateLook();
    }

    /// <summary>
    /// Handles the Rabbit button click event. Sets the pet type to Rabbit
    /// </summary>
    public void RabbitButtonOnClick()
    {
        petData.animalType = PlayerData.AnimalType.Rabbit;
        petPrefabObject.UpdateLook();
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
        SceneChange.LoadOptions();
    }
}
