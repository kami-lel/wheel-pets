using System;
using UnityEngine;

// TODO implement cat & rabbit
public class PetScript : MonoBehaviour
{
    // TODO alternative animation not implemented
    // [SerializeField]
    // private string animationName = "idle";

    // TODO show name of the pet above
    // [SerializeField]
    // private bool showPetName = true;

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
    /// Plays the specified animation for the active pet.
    ///
    /// This method allows changing the pet's animation across all animal types,
    /// ensuring that the provided animation name is valid before playback.
    /// If the animation name is not valid, it defaults to "idle".
    ///
    /// :param animationName: The name of the animation to play (e.g., "idle",
    ///                       "walk", "attack").
    /// </summary>
    public void PlayAnimation(string animationName)
    {
        Debug.LogError("alternative animation not implemented yet");
        return; // TODO allow for alternative animation
        // this.animationName = animationName;
        // activeAnimation.Play(animationName);
    }

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

        // TODO
        // activeAnimation = activePet.GetComponent<Animation>();
        // activeAnimation.Play(animationName);

        UpdateLookColor();
        UpdateLookAccessory();

        if (Debug.isDebugBuild)
        {
            Debug.Log("PetPrefab\tLook Updated");
        }
    }

    private PlayerData.PetData petData;
    private GameObject activePet;
    private Animation activeAnimation; // TODO not implemented yet

    private void Start()
    {
        PlayerData data = Data.GetPlayerData();
        petData = data.petData;
        UpdateLook();
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
}
