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

    /// <summary>
    /// Checks whether the player has purchased a specific accessory.
    /// </summary>
    /// <param name="accessory">The accessory type to check for purchase status.</param>
    /// <returns>
    /// Returns true if the accessory has been purchased, false otherwise.
    /// This allows for verifying whether the item is already owned by the player.
    /// </returns>
    public bool HasPurchased(AccessoryType accessory)
    {
        return playerData.purchasedAccessories.Contains(accessory);
    }

    /// <summary>
    /// Determines whether an accessory can be purchased for the player.
    /// The accessory is purchasable if it has not been purchased yet
    /// and the player has enough coins to make the purchase.
    /// </summary>
    /// <param name="accessory">The accessory type to check for purchase status.</param>
    /// <returns>
    /// 0 if the accessory is purchasable,
    /// 1 if the accessory has already been purchased,
    /// 2 if there are not enough coins to make the purchase.
    /// </returns>
    public byte IsPurchasable(AccessoryType accessory)
    {
        if (HasPurchased(accessory))
        {
            return 1;
        }
        else if (playerData.minigameCoin < ACCESSORY_PRICES[accessory])
        {
            return 2;
        }

        return 0;
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
        byte isPurchasable = IsPurchasable(accessory);

        if (isPurchasable == 0)
        {
            // Success: accessory is purchasable
            // deduct money / coin
            int price = ACCESSORY_PRICES[accessory];
            playerData.minigameCoin -= price;

            // add to inventory
            playerData.purchasedAccessories.Add(accessory);
        }

        if (Debug.isDebugBuild)
        {
            switch (isPurchasable)
            {
                case 0:
                    Debug.Log(
                        "AccessoryManager\t"
                            + accessory.ToString()
                            + "\tPurchased for "
                            + $"{ACCESSORY_PRICES[accessory]} coins"
                    );
                    break; // Proceed with purchase or further actions
                case 1:
                    Debug.Log(
                        "AccessoryManager\t"
                            + accessory.ToString()
                            + "\tCannot Purchase: Already Bought"
                    );
                    // Handle already purchased logic here
                    break;
                case 2:
                    Debug.Log(
                        "AccessoryManager\t"
                            + accessory.ToString()
                            + "\tCannot Purchase: Not Enough Coins"
                    );
                    // Handle insufficient coins logic here
                    break;
                default:
                    break;
            }
        }

        return isPurchasable;
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

    private PlayerData playerData;

    public AccessoryManager(PlayerData playerData)
    {
        this.playerData = playerData;
    }
}
