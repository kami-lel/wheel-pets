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

    public static ParameterData GetParameterData()
    {
        _parameterData ??= new();
        return _parameterData;
    }

    public static void LoadPlayerDataFromFile()
    {
        string saveFilePath = GenerateSaveFilePath();
        try
        {
            string jsonText = File.ReadAllText(saveFilePath);
            _playerData = JsonUtility.FromJson<PlayerData>(jsonText);
            if (_playerData == null)
            {
                throw new InvalidOperationException(
                    "Failed to deserialize PlayerData from JSON."
                );
            }

            if (Debug.isDebugBuild)
            {
                Debug.Log($"Data\tPlayer Data load from File: {saveFilePath}");
            }
        }
        catch (Exception ex)
        {
            if (
                ex is FileNotFoundException
                || ex is ArgumentException
                || ex is InvalidOperationException
            )
            {
                // create an default PlayerData instance
                _playerData = new PlayerData();

                if (Debug.isDebugBuild)
                {
                    Debug.LogWarning(
                        $"Data\tPlayer Data Fail to Load from file: {saveFilePath}. An empty player data is used."
                    );
                }
            }
            else
            {
                throw;
            }
        }

        // create a accessory manager that is linked with playerData
        accessoryManager = new AccessoryManager(_playerData);
        pointCoinManager = new PointCoinManager(_playerData);
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
                Debug.Log($"Data\tPlayer Data save to file: {saveFilePath}");
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
                        $"Data\tPlayer Data fail to save to file: {saveFilePath}"
                    );
                }
        }
    }

    public static void ResetPlayerData()
    {
        _playerData = new PlayerData();
        SavePlayerDataToFile();
        if (Debug.isDebugBuild)
        {
            Debug.Log("Data\tPlayer Data Reset");
        }
    }

    public static AccessoryManager accessoryManager;
    public static PointCoinManager pointCoinManager;
    private static PlayerData _playerData = null;
    private static ParameterData _parameterData = null;

    private static string GenerateSaveFilePath()
    {
        string fileName = "playerData";
        string fileExtension = ".json";
        string folderPath = Application.isEditor
            ? Directory.GetParent(Application.dataPath).FullName
            : Application.persistentDataPath;

        string filePath = Path.Combine(folderPath, fileName + fileExtension);
        return filePath;
    }
}
