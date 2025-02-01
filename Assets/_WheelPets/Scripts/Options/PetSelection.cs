using UnityEngine;
using UnityEngine.UI;

public class PetSelection : MonoBehaviour
{
    public Button catButton;
    public Button dogButton;
    public Button bunnyButton;
    public Image petImage;

    public Sprite catSprite;
    public Sprite dogSprite;
    public Sprite bunnySprite;

    void Start()
    {
        // Assign button click listeners
        catButton.onClick.AddListener(() => ChangePetImage(catSprite));
        dogButton.onClick.AddListener(() => ChangePetImage(dogSprite));
        bunnyButton.onClick.AddListener(() => ChangePetImage(bunnySprite));
    }

    void ChangePetImage(Sprite newSprite)
    {
        if (petImage != null && newSprite != null)
        {
            petImage.sprite = newSprite;
        }
    }
}
