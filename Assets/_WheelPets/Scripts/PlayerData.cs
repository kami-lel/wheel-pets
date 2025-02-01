using System;
using System.IO;
using UnityEngine;

[Serializable]
class PlayerData
{
    public static PlayerData instance;

    /// <summary>
    /// Loads player data from a file. I.e. load into PlayerData.instance
    /// </summary>
    public static void LoadFromFile()
    {
        string saveFilePath = GetSaveFilePath();

        try
        {
            string jsonText = File.ReadAllText(saveFilePath);
            instance = JsonUtility.FromJson<PlayerData>(jsonText);

            if (Debug.isDebugBuild)
            {
                Debug.Log($"PlayerData\tLoad from File: {saveFilePath}");
            }
        }
        catch (Exception ex)
        {
            if (ex is FileNotFoundException || ex is ArgumentException)
            {
                // create an default PlayerData instance
                instance = new PlayerData();

                if (Debug.isDebugBuild)
                {
                    Debug.LogWarning(
                        $"PlayerData\tFail to Load from file: {saveFilePath}. An empty player data is used."
                    );
                }
            }
        }
    }

    /// <summary>
    /// save player data to a file. I.e. save PlayerData.instance
    /// </summary>
    public static void SaveToFile()
    {
        string saveFilePath = GetSaveFilePath();
        string jsonText = JsonUtility.ToJson(instance);

        try
        {
            File.WriteAllText(saveFilePath, jsonText);

            if (Debug.isDebugBuild)
            {
                Debug.Log($"PlayerData\tSave to File: {saveFilePath}");
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
                    Debug.LogError($"PlayerData\tFail to Save to file: {saveFilePath}");
                }
        }
    }

    /// <summary>
    /// resets the player data and saving it to the file.
    /// </summary>
    public static void ResetPlayerData()
    {
        instance = new PlayerData();
        SaveToFile();
    }

    private static string GetSaveFilePath()
    {
        string fileName = "playerData";
        string filePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
        return filePath;
    }
}
