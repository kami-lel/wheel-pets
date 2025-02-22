using System;
using UnityEngine;

// todo show name of the pet above
// TODO remove unusable pet accessories
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
        // fixme make sure all accessories are placed properly

        Transform accessoryGroupTransform = activePet.transform.Find(
            "AccessoryGroup"
        );
        if (Debug.isDebugBuild && accessoryGroupTransform == null)
        {
            Debug.LogError(
                "PetPrefab\tCan't find AccessoryGroup in " + activePet
            );
        }

        // loop via all possible accessories in enum PetAccessory
        foreach (
            PlayerData.PetAccessory accessory in Enum.GetValues(
                typeof(PlayerData.PetAccessory)
            )
        )
        {
            // find accessory as game object
            string accessoryName = accessory.ToString();
            Transform accessoryTransform =
                accessoryGroupTransform.transform.Find(accessoryName);
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
