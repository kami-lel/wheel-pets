using System;
using UnityEngine;
using UnityEngine.UI;

public class StoreAccessoryEntry : MonoBehaviour
{
    [SerializeField]
    private Button purchaseButton;

    [SerializeField]
    private Button equipButton;

    [SerializeField]
    private Button unequipButton;

    [SerializeField]
    private GameObject accessorySprite;

    private PlayerData.PetAccessory accessory;

    private void Start()
    {
        // attempt to decide what accessory this prefab is containing
        // based on **name** of accessory sprite
        bool result = Enum.TryParse<PlayerData.PetAccessory>(
            accessorySprite.name,
            out PlayerData.PetAccessory accessory_temp
        );
        if (Debug.isDebugBuild && !result)
        {
            Debug.LogWarning(
                "StoreAccessoryEntry Prefab\t"
                    + "Can not decide which accessory contained, "
                    + "make sure name of sprite gameobject match "
                    + "exactly PlayerData.PetAccessory"
            );
        }
        accessory = accessory_temp;
    }

    public void OnClickPurchaseButton()
    {
        // TODO Implement purchase logic here
    }

    public void OnClickEquipButton()
    {
        // TODO Implement equip logic here
    }

    public void OnClickUnequipButton()
    {
        // TODO Implement unequip logic here
    }
}
