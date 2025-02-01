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

    private PlayerData playerData;
    private PlayerData.PetData petData;

    void Start()
    {
        playerData = PlayerData.LoadFromFile(); // FIXME rm
        petData = playerData.petData;
    }

    void Update() { }
}
