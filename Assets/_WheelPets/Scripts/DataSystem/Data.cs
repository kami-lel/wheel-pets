using System;
using System.IO;
using UnityEngine;

public class Data
{
    public static PlayerData GetPlayerData()
    {
        if (_playerData == null)
        {
            LoadPlayerDataFromFile();
        }
        return _playerData;
    }

    public static ParameterData parameterData = new();

    public static void LoadPlayerDataFromFile()
    {
        string saveFilePath = GenerateSaveFilePath();
        try
        {
            string jsonText = File.ReadAllText(saveFilePath);
            _playerData = JsonUtility.FromJson<PlayerData>(jsonText);

            if (Debug.isDebugBuild)
            {
                Debug.Log($"Data\tload from File: {saveFilePath}");
            }
        }
        catch (Exception ex)
        {
            if (ex is FileNotFoundException || ex is ArgumentException)
            {
                // create an default PlayerData instance
                _playerData = new PlayerData();

                if (Debug.isDebugBuild)
                {
                    Debug.LogWarning(
                        $"Data\tFail to Load from file: {saveFilePath}. An empty player data is used."
                    );
                }
            }
            else
            {
                throw;
            }
        }
    }

    public static void SavePlayerDataToFile()
    {
        string saveFilePath = GenerateSaveFilePath();

        string jsonText = JsonUtility.ToJson(_playerData, Debug.isDebugBuild);

        try
        {
            File.WriteAllText(saveFilePath, jsonText);

            if (Debug.isDebugBuild)
            {
                Debug.Log($"Data\tsave to file: {saveFilePath}");
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
                    Debug.LogError(
                        $"Data\tfail to save to file: {saveFilePath}"
                    );
                }
        }
    }

    private static PlayerData _playerData = null;

    private static string GenerateSaveFilePath()
    {
        string fileName = "playerData";
        string filePath = Path.Combine(
            Application.persistentDataPath,
            fileName + ".json"
        );
        return filePath;
    }
}
