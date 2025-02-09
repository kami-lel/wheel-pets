using UnityEngine;

class Data
{
    public static PlayerData LoadPlayerData(MonoBehaviour script)
    {
        // TODO
        return new PlayerData();
    }

    public static GameData LoadGameData()
    {
        // TODO
        return new GameData();
    }

    /// <summary>
    /// PlayerData class holds data related to the player,
    /// which is persistent across play sessions but can be reset.
    /// It typically includes information such as player's name, level, health, etc.
    /// </summary>
    [System.Serializable]
    public class PlayerData
    {
        // TODO
    }

    /// <summary>
    /// GameData class is used for saving tuning parameters, economics data, etc.
    /// This ensures that non-player specific game settings and values are maintained.
    /// </summary>
    [System.Serializable]
    public class GameData
    {
        // TODO
    }
}
