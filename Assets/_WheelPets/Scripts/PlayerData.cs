using System;
using System.IO;
using UnityEngine;

[Serializable]
class PlayerData
{
    public static PlayerData Data
    {
        get
        {
            if (_data == null)
            {
                LoadFromFile();
            }
            return _data;
        }
    }

    // declare persistent data fields
    // initialize with <b>default value</b>, i.e. factory reset value
    public string playerName = "Pet Owner";
    public int drivingPoint = 0;
    public int gamePoint = 0;
    public float drivingMiles = 0;

    public LeaderboardOtherPlayerData[] leaderBoardOtherPlayerData =
    {
        new LeaderboardOtherPlayerData { name = "John", point = 123 },
        new LeaderboardOtherPlayerData { name = "Emma", point = 234 },
        new LeaderboardOtherPlayerData { name = "Oliver", point = 198 },
        new LeaderboardOtherPlayerData { name = "Sophia", point = 265 },
        new LeaderboardOtherPlayerData { name = "Liam", point = 121 },
        new LeaderboardOtherPlayerData { name = "Ava", point = 289 },
        new LeaderboardOtherPlayerData { name = "Ethan", point = 177 },
        new LeaderboardOtherPlayerData { name = "Isabella", point = 256 },
        new LeaderboardOtherPlayerData { name = "Mason", point = 210 },
        new LeaderboardOtherPlayerData { name = "Mia", point = 178 },
    };

    // New driving statistics
    public int leftTurnSignals = 0;
    public int rightTurnSignals = 0;
    public int timesParkedWithoutTouchingLines = 0;
    public int stopSignsStoppedAt = 0;

    // New minigame statistics
    public int tugOfWarGamesWon = 0;
    public int timesPetWashed = 0;
    public int timesHideNSeekWon = 0;
    public int cosmeticsUnlocked = 0;

    // Audio settings
    public float musicVolume = 1f;
    public float sfxVolume = 1f;
    public bool muteMusic = false;
    public bool muteSfx = false;

    /// <summary>
    /// statistics of mini games
    /// </summary>
    public MinigameStatistics statBath = new();
    public MinigameStatistics statFeed = new();
    public MinigameStatistics statFetch = new();
    public MinigameStatistics statHideNSeek = new();
    public MinigameStatistics statTugOWar = new();
    public MinigameStatistics statWalkScene = new();

    // pet's data
    public bool hasAdoptPet = false;
    public PetData petData = new();

    [Serializable]
    public class LeaderboardOtherPlayerData
    {
        public string name;
        public int point;
    }

    [Serializable]
    public class MinigameStatistics
    {
        public int playCount = 0;
        public int winCount = 0;
    }

    [Serializable]
    public class PetData
    {
        public string name = "Buddy";
        public int animalType = 0;
        public float dominantColorHue = 0f;
        public float secondaryColorHue = 0f;
    }

    /// <summary>
    /// Loads player data from a file. I.e. load into PlayerData.instance
    /// </summary>
    public static PlayerData LoadFromFile()
    {
        string saveFilePath = GetSaveFilePath();

        try
        {
            string jsonText = File.ReadAllText(saveFilePath);
            _data = JsonUtility.FromJson<PlayerData>(jsonText);

            if (Debug.isDebugBuild)
            {
                Debug.Log($"PlayerData\tload from File: {saveFilePath}");
            }

            return _data;
        }
        catch (Exception ex)
        {
            if (ex is FileNotFoundException || ex is ArgumentException)
            {
                // create an default PlayerData instance
                _data = new PlayerData();

                if (Debug.isDebugBuild)
                {
                    Debug.LogWarning(
                        $"PlayerData\tFail to Load from file: {saveFilePath}. An empty player data is used."
                    );
                }

                return _data;
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// save player data to a file. I.e. save PlayerData.instance
    /// </summary>
    public static void SaveToFile()
    {
        string saveFilePath = GetSaveFilePath();

        string jsonText = JsonUtility.ToJson(_data, Debug.isDebugBuild);

        try
        {
            File.WriteAllText(saveFilePath, jsonText);

            if (Debug.isDebugBuild)
            {
                Debug.Log($"PlayerData\tsave to file: {saveFilePath}");
            }
        }
        catch (Exception ex)
        {
            if (
                ex is UnauthorizedAccessException
                || ex is ArgumentNullException
                || ex is DirectoryNotFoundException
            )
                if (Debug.isDebugBuild)
                {
                    Debug.LogError($"PlayerData\tfail to save to file: {saveFilePath}");
                }
        }
    }

    /// <summary>
    /// resets the player data and saving it to the file.
    /// </summary>
    public static void ResetPlayerData()
    {
        _data = new PlayerData();
        SaveToFile();
        Debug.Log("PlayerData\tReset");
    }

    private static string GetSaveFilePath()
    {
        string fileName = "playerData";
        string filePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
        return filePath;
    }

    private static PlayerData _data = null;
}
