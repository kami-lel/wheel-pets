using System;
using UnityEngine;

public class PetScript : MonoBehaviour
{
    // todo alternative animation not implemented
    // [SerializeField]
    // private string animationName = "idle";

    // todo show name of the pet above
    // todo select a random name
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
        return; // todo allow for alternative animation
        // this.animationName = animationName;
        // activeAnimation.Play(animationName);
    }

    /// <summary>
    /// Updates the appearance of the pet from data.petData
    /// </summary>
    public void UpdateLook()
    {
        // decide type of the animal
        activePet = data.petData.animalType switch
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

        // todo
        // activeAnimation = activePet.GetComponent<Animation>();
        // activeAnimation.Play(animationName);

        UpdateLookColor();
        UpdateLookAccessory();

        if (Debug.isDebugBuild)
        {
            Debug.Log("PetPrefab\tLook Updated");
        }
    }

    private GameObject activePet;
    private PlayerData data;
    private Animation activeAnimation; // todo not implemented yet

    private void Start()
    {
        data = Data.GetPlayerData();
        UpdateLook();
    }

    private void UpdateLookColor()
    {
        Color dominantColor,
            secondaryColor;

        // map hue value to actual color
        // fixme parameter can be better
        switch (data.petData.animalType)
        {
            case PlayerData.AnimalType.Dog:
            default:
                dominantColor = CreateColorDom(
                    -0.06f,
                    0.15f,
                    0.8f,
                    0.65f,
                    0.7f,
                    0.9f
                );
                secondaryColor = CreateColorSec(
                    0f,
                    1f,
                    0.1f,
                    0.2f,
                    1.0f,
                    1.0f
                );
                break;

            case PlayerData.AnimalType.Cat:
                dominantColor = CreateColorSec(
                    -0.06f,
                    0.15f,
                    0.8f,
                    0.65f,
                    0.7f,
                    0.9f
                );
                secondaryColor = CreateColorDom(
                    0f,
                    1f,
                    0.1f,
                    0.2f,
                    1.0f,
                    1.0f
                );
                break;

            case PlayerData.AnimalType.Rabbit:
                dominantColor = CreateColorDom(
                    -0.06f,
                    0.15f,
                    0.8f,
                    0.65f,
                    0.7f,
                    0.9f
                );
                secondaryColor = CreateColorSec(
                    0f,
                    1f,
                    0.1f,
                    0.2f,
                    1.0f,
                    1.0f
                );
                break;
        }

        // update primary color
        SpriteRenderer dominantRenderer = activePet
            .transform.Find("Dominant")
            .gameObject.GetComponent<SpriteRenderer>();
        dominantRenderer.color = dominantColor;
        ;

        // update secondary color
        SpriteRenderer secondaryRenderer = activePet
            .transform.Find("Secondary")
            .gameObject.GetComponent<SpriteRenderer>();
        secondaryRenderer.color = secondaryColor;
    }

    private Color CreateColorDom(
        float hBegin,
        float hEnd,
        float sBegin,
        float sEnd,
        float vBegin,
        float vEnd
    )
    {
        float value = data.petData.dominantColorHue;
        // HACK
        Debug.LogWarning(data.petData.dominantColorHue.ToString());
        return CreateColorFromRange(
            value,
            hBegin,
            hEnd,
            sBegin,
            sEnd,
            vBegin,
            vEnd,
            true
        );
    }

    private Color CreateColorSec(
        float hBegin,
        float hEnd,
        float sBegin,
        float sEnd,
        float vBegin,
        float vEnd
    )
    {
        float value = data.petData.secondaryColorHue;
        return CreateColorFromRange(
            value,
            hBegin,
            hEnd,
            sBegin,
            sEnd,
            vBegin,
            vEnd,
            false
        );
    }

    private Color CreateColorFromRange(
        float hueValue,
        float hBegin,
        float hEnd,
        float sBegin,
        float sEnd,
        float vBegin,
        float vEnd,
        bool isDom
    )
    {
        float h = Lerp(hueValue, hBegin, hEnd);
        float s = Lerp(hueValue, sBegin, sEnd);
        float v = Lerp(hueValue, vBegin, vEnd);

        if (Debug.isDebugBuild)
        {
            Debug.Log(
                "Pet\t"
                    + (isDom ? "Dominant" : "Secondary")
                    + $"Color\th:{h} s:{s} v:{v}"
            );
        }

        return Color.HSVToRGB(h, s, v);
    }

    private float Lerp(float value, float opt_begin, float opt_end)
    {
        // optimization
        if (opt_begin == opt_end)
        {
            return opt_begin;
        }
        else if (opt_begin == 0f && opt_end == 1f)
        {
            return value;
        }

        float output = opt_begin + value * (opt_end - opt_begin);
        // Adjust output based on value conditions
        if (output < 0)
        {
            output += 1f; // Add 1 if value is less than 0
        }
        else if (output > 1)
        {
            output -= 1f; // Subtract 1 if value is greater than 1
        }
        return output;
    }

    private void UpdateLookAccessory()
    {
        // decide type of the animal
        GameObject activePetAccessoryGroup = data.petData.animalType switch
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
                bool isWearing = data.petData.currentAccessories.Contains(
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
