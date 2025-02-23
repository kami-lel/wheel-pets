using System;
using UnityEngine;

public class AccessoryManager
{
    private PlayerData playerData;

    public AccessoryManager(PlayerData playerData)
    {
        this.playerData = playerData;
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
        else if (false) // todo check if has enough point
        {
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

        // todo deduct money logic
        playerData.purchasedAccessories.Add(accessory);

        if (Debug.isDebugBuild)
        {
            Debug.Log(
                "AccessoryManager\t" + accessory.ToString() + "\tPurchased"
            );
        }
        return 0;
    }

    public bool HasPurchased(AccessoryType accessory)
    {
        return playerData.purchasedAccessories.Contains(accessory);
    }
}
