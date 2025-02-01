using System;
using System.Data.Common;
using System.IO;
using UnityEngine;

[System.Serializable]
class PlayerData
{
    public static PlayerData instance;

    public static void LoadFromFile()
    {
        string saveFilePath = GetSaveFilePath();

        try
        {
            string jsonText = File.ReadAllText(saveFilePath);
            instance = JsonUtility.FromJson<PlayerData>(jsonText);

            // TODO
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
                    Debug.LogWarning($"PlayerData\tFail to Load from file: {saveFilePath}");
                }
            }
        }
    }

    public static void SaveToFile(PlayerData playerData)
    {
        // TODO
    }

    private static string GetSaveFilePath()
    {
        string fileName = "playerData";
        string filePath = Path.Combine(Application.persistentDataPath, fileName + ".json");
        return filePath;
    }
}
