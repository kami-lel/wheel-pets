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

    private PetScript petPrefab;
    private AccessoryType accessoryType;
    private PlayerData playerData;

    private void Start()
    {
        petPrefab = FindFirstObjectByType<PetScript>();
        playerData = Data.GetPlayerData();

        // attempt to decide what accessory this prefab is containing
        // based on **name** of accessory sprite
        bool result = Enum.TryParse<AccessoryType>(
            gameObject.name,
            out AccessoryType accessory_temp
        );
        if (Debug.isDebugBuild && !result)
        {
            Debug.LogWarning(
                "StoreAccessoryEntry Prefab\t"
                    + "Can not decide which accessory contained, "
                    + "make sure name of Prefab match "
                    + "exactly AccessoryType"
            );
        }
        accessoryType = accessory_temp;

        UpdateButtonInteractable();
    }

    public void OnClickPurchaseButton()
    {
        Data.accessoryManager.Purchase(accessoryType);
        UpdateButtonInteractable();
        petPrefab.UpdateLook();
    }

    public void OnClickEquipButton()
    {
        Data.accessoryManager.Equip(accessoryType);
        UpdateButtonInteractable();
        petPrefab.UpdateLook();
    }

    public void OnClickUnequipButton()
    {
        Data.accessoryManager.Unequip(accessoryType);
        UpdateButtonInteractable();
        petPrefab.UpdateLook();
    }

    /// <summary>
    /// Updates the interactable property of all buttons based on player data.
    /// This method ensures that the buttons in the store accessory entry
    /// are enabled or disabled according to the current state of the
    /// player's data, such as whether they can afford an accessory or if
    /// they are currently equipped with it.
    /// </summary>
    private void UpdateButtonInteractable()
    {
        bool purchased = Data.accessoryManager.HasPurchased(accessoryType);
        bool wearing = Data.accessoryManager.IsWearing(accessoryType);

        purchaseButton.interactable = !purchased;
        equipButton.interactable = purchased && !wearing;
        unequipButton.interactable = wearing;
    }
}
