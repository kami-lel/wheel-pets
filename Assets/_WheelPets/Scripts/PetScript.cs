using UnityEngine;

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
            0 => dog,
            1 => cat,
            2 => rabbit,
            _ => dog,
        };

        dog.SetActive(false);
        cat.SetActive(false);
        rabbit.SetActive(false);
        activePet.SetActive(true);

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

        if (Debug.isDebugBuild)
        {
            Debug.Log("Pet\tLook Updated");
        }
    }

    // TODO use new data system
    private PlayerData playerData;
    private PlayerData.PetData petData;
    private GameObject activePet;

    private void Start()
    {
        // TODO use new data system
        playerData = PlayerData.Data;
        petData = playerData.petData;
        UpdateLook();
    }
}
