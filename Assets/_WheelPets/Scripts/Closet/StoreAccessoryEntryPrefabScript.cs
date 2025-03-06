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

    private PetScript petPrefab;
    private AccessoryType accessoryType;

    private void Start()
    {
        Data.GetPlayerData();
        petPrefab = FindFirstObjectByType<PetScript>();

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
        purchaseButton.gameObject.SetActive(false);
    }

    public void OnClickEquipButton()
    {
        Data.accessoryManager.Equip(accessoryType);
        UpdateButtonInteractable();
        petPrefab.UpdateLook();
        unequipButton.gameObject.SetActive(true);
        equipButton.gameObject.SetActive(false);
    }

    public void OnClickUnequipButton()
    {
        Data.accessoryManager.Unequip(accessoryType);
        UpdateButtonInteractable();
        petPrefab.UpdateLook();
        equipButton.gameObject.SetActive(true);
        unequipButton.gameObject.SetActive(false);
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
        bool isPurchasable = (
            Data.accessoryManager.IsPurchasable(accessoryType) == 0
        );
        bool purchased = Data.accessoryManager.HasPurchased(accessoryType);
        bool wearing = Data.accessoryManager.IsWearing(accessoryType);

        purchaseButton.gameObject.SetActive(!purchased);
        purchaseButton.interactable = isPurchasable;
        equipButton.gameObject.SetActive(purchased && !wearing);
        unequipButton.gameObject.SetActive(wearing);
    }
}
