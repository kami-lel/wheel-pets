using UnityEngine;
using UnityEngine.UI;

public class ColorSelection : MonoBehaviour
{
    public Button brownButton;
    public Button greyButton;
    public Button orangeButton;

    private PetSelection petSelection;
    private Image petImage;

    void Start()
    {
        // Find the PetSelection script in the scene
        petSelection = FindObjectOfType<PetSelection>();

        if (petSelection != null)
        {
            petImage = petSelection.petImage;
        }

        // Assign button click listeners
        brownButton.onClick.AddListener(() => ChangePetColor(ColorUtility.TryParseHtmlString("#8B4513", out Color brown) ? brown : Color.white));
        greyButton.onClick.AddListener(() => ChangePetColor(Color.grey));
        orangeButton.onClick.AddListener(() => ChangePetColor(ColorUtility.TryParseHtmlString("#FFA500", out Color orange) ? orange : Color.white));
    }

    void ChangePetColor(Color newColor)
    {
        if (petImage != null)
        {
            petImage.color = newColor; // Change the image color
        }
    }
}
