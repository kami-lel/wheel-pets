using System;
using UnityEngine;

// todo show name of the pet above
// todo implement cat & rabbit
// fixme make sure all accessories are placed properly
// fixme make sure accessories render order is correct, chain should be above glasses, etc.
public class PetScript : MonoBehaviour
{
    [SerializeField]
    private GameObject dog;

    [SerializeField]
    private GameObject dogAccessoryGroup;

    [SerializeField]
    private GameObject cat;

    [SerializeField]
    private GameObject catAccessoryGroup;

    [SerializeField]
    private GameObject rabbit;

    [SerializeField]
    private GameObject rabbitAccessoryGroup;

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
        Debug.Log("PetPrefab\tSelect: " + activePet);

        UpdateLookColor();
        UpdateLookAccessory();

        if (Debug.isDebugBuild)
        {
            Debug.Log("PetPrefab\tLook Updated");
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
        // decide type of the animal
        GameObject activePetAccessoryGroup = petData.animalType switch
        {
            PlayerData.AnimalType.Dog => dogAccessoryGroup,
            PlayerData.AnimalType.Cat => catAccessoryGroup,
            PlayerData.AnimalType.Rabbit => rabbitAccessoryGroup,
            _ => dogAccessoryGroup,
        };

        // loop via all possible accessories in enum AccessoryType
        foreach (
            AccessoryType accessory in Enum.GetValues(typeof(AccessoryType))
        )
        {
            // find accessory as game object
            string accessoryName = accessory.ToString();
            Transform accessoryTransform =
                activePetAccessoryGroup.transform.Find(accessoryName);
            if (accessoryTransform != null)
            {
                // set active condition
                bool isWearing = petData.currentAccessories.Contains(
                    accessory
                );
                accessoryTransform.gameObject.SetActive(isWearing);
            }
            else if (Debug.isDebugBuild)
            {
                Debug.LogWarning(
                    "PetPrefab\tcan't find accessory as game object:"
                        + accessoryName
                );
            }
        }
    }

    private PlayerData.PetData petData;
    private GameObject activePet;

    private void Start()
    {
        petData = Data.GetPlayerData().petData;
        UpdateLook();
    }
}
