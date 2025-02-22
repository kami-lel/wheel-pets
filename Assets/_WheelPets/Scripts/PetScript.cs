using UnityEngine;

// TODO implement pet wearing hats, etc.
public class PetScript : MonoBehaviour
{
    [SerializeField]
    private GameObject dog;

    [SerializeField]
    private GameObject cat;

    [SerializeField]
    private GameObject rabbit;

    /// <summary>
    /// Updates the appearance of the pet from petData
    /// </summary>
    public void UpdateLook()
    {
        // decide type of the animal
        activePet = petData.animalType switch
        {
            PlayerData.AnimalType.Dog => dog,
            PlayerData.AnimalType.Cat => cat,
            PlayerData.AnimalType.Rabbit => rabbit,
            _ => dog,
        };

        dog.SetActive(false);
        cat.SetActive(false);
        rabbit.SetActive(false);
        activePet.SetActive(true);
        Debug.Log("Pet\tSelect: " + activePet);

        UpdateLookColor();

        if (Debug.isDebugBuild)
        {
            Debug.Log("Pet\tLook Updated");
        }
    }

    private void UpdateLookColor()
    {
        // update dominant color
        SpriteRenderer dominantRenderer = activePet
            .transform.Find("Dominant")
            .gameObject.GetComponent<SpriteRenderer>();
        dominantRenderer.color = Color.HSVToRGB(
            petData.dominantColorHue,
            0.8f,
            0.2f
        );

        // update secondary color
        SpriteRenderer secondaryRenderer = activePet
            .transform.Find("Secondary")
            .gameObject.GetComponent<SpriteRenderer>();
        secondaryRenderer.color = Color.HSVToRGB(
            petData.secondaryColorHue,
            0.1f,
            1f
        );
    }

    private void UpdateLookAccessory()
    {
        // TODO update accessory situation
    }

    private PlayerData.PetData petData;
    private GameObject activePet;

    private void Start()
    {
        petData = Data.GetPlayerData().petData;
        UpdateLook();
    }
}
