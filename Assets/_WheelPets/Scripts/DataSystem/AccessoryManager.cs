using System;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryManager
{
    private static Dictionary<AccessoryType, int> ACCESSORY_PRICES =
        new Dictionary<AccessoryType, int>
        {
            { AccessoryType.Bowtie, 50 },
            { AccessoryType.Tie, 75 },
            { AccessoryType.Chain, 100 },
            { AccessoryType.CapHat, 125 },
            { AccessoryType.CowboyHat, 150 },
            { AccessoryType.TopHat, 175 },
            { AccessoryType.AngularChevronGlasses, 60 },
            { AccessoryType.RectangularGlasses, 85 },
            { AccessoryType.SpikedEdgeGlasses, 110 },
            { AccessoryType.WingGlasses, 145 },
        };

    private PlayerData playerData;

    public AccessoryManager(PlayerData playerData)
    {
        this.playerData = playerData;
    }

    public bool HasPurchased(AccessoryType accessory)
    {
        return playerData.purchasedAccessories.Contains(accessory);
    }

    /// <summary>
    /// Tries to purchase an accessory for the player.
    /// </summary>
    /// <param name="accessory">The accessory type to purchase.</param>
    /// <returns>
    /// 0 if the purchase was successful,
    /// 1 if the accessory has already been purchased,
    /// 2 if there are not enough points to make the purchase.
    /// </returns>
    public byte Purchase(AccessoryType accessory)
    {
        int price = ACCESSORY_PRICES[accessory];
        if (HasPurchased(accessory))
        {
            if (Debug.isDebugBuild)
            {
                Debug.Log(
                    "AccessoryManager\t"
                        + accessory.ToString()
                        + "\tFail to Purchase: already bought"
                );
            }
            return 1;
        }
        else if (playerData.minigameCoin < price)
        {
            // doesn't have enough money
            if (Debug.isDebugBuild)
            {
                Debug.Log(
                    "AccessoryManager\t"
                        + accessory.ToString()
                        + "\tFail to Purchase: not enough money"
                );
            }
            return 2;
        }

        // deduct money / coin
        playerData.minigameCoin -= price;

        // add to inventory
        playerData.purchasedAccessories.Add(accessory);

        if (Debug.isDebugBuild)
        {
            Debug.Log(
                "AccessoryManager\t"
                    + accessory.ToString()
                    + $"\tPurchased for {price} coins"
            );
        }
        return 0;
    }

    public bool IsWearing(AccessoryType accessory)
    {
        return HasPurchased(accessory)
            && playerData.petData.currentAccessories.Contains(accessory);
    }

    /// <summary>
    /// Tries to equip an accessory for the player.
    /// </summary>
    /// <param name="accessory">The accessory type to equip.</param>
    /// <returns>
    /// 0 if the equip was successful,
    /// 1 if the accessory has not been purchased,
    /// 2 if the accessory is already equipped.
    /// </returns>
    public byte Equip(AccessoryType accessory)
    {
        if (!HasPurchased(accessory))
        {
            if (Debug.isDebugBuild)
            {
                Debug.Log(
                    "AccessoryManager\t"
                        + accessory.ToString()
                        + "\tFail to Equip: Not Purchased"
                );
            }
            return 1;
        }
        else if (IsWearing(accessory))
        {
            if (Debug.isDebugBuild)
            {
                Debug.Log(
                    "AccessoryManager\t"
                        + accessory.ToString()
                        + "\tFail to Equip: Already Equipped"
                );
            }
            return 2;
        }

        // add to wearing
        playerData.petData.currentAccessories.Add(accessory);

        if (Debug.isDebugBuild)
        {
            Debug.Log(
                "AccessoryManager\t" + accessory.ToString() + "\tEquipped"
            );
        }
        return 0;
    }

    /// <summary>
    /// Tries to unequip an accessory for the player.
    /// </summary>
    /// <param name="accessory">The accessory type to unequip.</param>
    /// <returns>
    /// 0 if the unequip was successful,
    /// 1 if the accessory is not currently equipped,
    /// 2 if the accessory was not previously purchased.
    /// </returns>
    public byte Unequip(AccessoryType accessory)
    {
        if (!HasPurchased(accessory))
        {
            if (Debug.isDebugBuild)
            {
                Debug.Log(
                    "AccessoryManager\t"
                        + accessory.ToString()
                        + "\tFail to Unequip: Not Purchased"
                );
            }
            return 2; // Accessory not purchased
        }
        else if (!IsWearing(accessory))
        {
            if (Debug.isDebugBuild)
            {
                Debug.Log(
                    "AccessoryManager\t"
                        + accessory.ToString()
                        + "\tFail to Unequip: Not Equipped"
                );
            }
            return 1; // Accessory not currently equipped
        }

        // remove from wearing
        playerData.petData.currentAccessories.Remove(accessory);

        if (Debug.isDebugBuild)
        {
            Debug.Log(
                "AccessoryManager\t" + accessory.ToString() + "\tUnequipped"
            );
        }
        return 0; // Successfully unequipped
    }
}
