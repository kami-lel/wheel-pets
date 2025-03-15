using UnityEngine;
using UnityEngine.Localization.Settings;

public class DataSystemPrefabScript : MonoBehaviour
{
    [SerializeField]
    private float autoSaveIntervalSec = 15f; // Auto-save interval in seconds

    private float lastSaveTime = 0f; // Last save time tracker

    private void Start()
    {
        // set language when game start
        string localeCode = Data.GetPlayerData().language;

        var selectedLocale =
            LocalizationSettings.AvailableLocales.Locales.Find(locale =>
                locale.Identifier.Code == localeCode
            );
        if (selectedLocale != null)
        {
            LocalizationSettings.SelectedLocale = selectedLocale;
            Debug.Log($"Locale set to {localeCode}");
        }
        else
        {
            Debug.LogWarning($"Locale {localeCode} not found");
        }
    }

    private void Update()
    {
        // Check if the difference between the current time and the last save time
        // is greater than or equal to the auto-save interval
        if (Time.time - lastSaveTime >= autoSaveIntervalSec)
        {
            Data.SavePlayerDataToFile(); // Perform the auto-save
            lastSaveTime = Time.time; // Update last save time

            if (Debug.isDebugBuild)
            {
                Debug.Log("Data\tAuto-Saved");
            }
        }
    }

    void OnApplicationQuit()
    {
        Data.SavePlayerDataToFile();
    }
}
