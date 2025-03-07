using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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

    private List<StoreAccessoryEntry> entries;

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

        // give button its price value
        purchaseButton
            .transform.GetChild(0)
            .GetComponent<TMP_Text>()
            .SetText(Data.accessoryManager.GetPrice(accessoryType).ToString());
        SetupEntries();
        UpdateAllButtons();
    }

    public void OnClickPurchaseButton()
    {
        Data.accessoryManager.Purchase(accessoryType);
        UpdateAllButtons();
        petPrefab.UpdateLook();
    }

    public void OnClickEquipButton()
    {
        Data.accessoryManager.Equip(accessoryType);
        UpdateAllButtons();
        petPrefab.UpdateLook();
    }

    public void OnClickUnequipButton()
    {
        Data.accessoryManager.Unequip(accessoryType);
        UpdateAllButtons();
        petPrefab.UpdateLook();
    }

    /// <summary>
    /// Updates the interactable property of all buttons based on player data.
    /// This method ensures that the buttons in the store accessory entry
    /// are enabled or disabled according to the current state of the
    /// player's data, such as whether they can afford an accessory or if
    /// they are currently equipped with it.
    /// </summary>
    public void UpdateButtonInteractable()
    {
        bool purchased = Data.accessoryManager.HasPurchased(accessoryType);
        bool wearing = Data.accessoryManager.IsWearing(accessoryType);

        if (purchased)
        {
            purchaseButton.gameObject.SetActive(false);
            if (wearing)
            {
                equipButton.gameObject.SetActive(false);
                unequipButton.gameObject.SetActive(true);
            }
            else
            {
                equipButton.gameObject.SetActive(true);
                unequipButton.gameObject.SetActive(false);
            }
        }
        else
        {
            purchaseButton.gameObject.SetActive(true);

            bool isPurchasable =
                Data.accessoryManager.IsPurchasable(accessoryType) == 0;
            purchaseButton.interactable = isPurchasable;

            equipButton.gameObject.SetActive(false);
            unequipButton.gameObject.SetActive(false);
        }
    }

    private void SetupEntries()
    {
        entries = new List<StoreAccessoryEntry>();
        if (transform.parent != null)
        {
            foreach (Transform entryTransform in transform.parent)
            {
                entries.Add(entryTransform.gameObject.GetComponent<StoreAccessoryEntry>());
            }
        }
    }

    private void UpdateAllButtons()
    {
        foreach(StoreAccessoryEntry entry in entries)
        {
            entry.UpdateButtonInteractable();
        }
    }
}
