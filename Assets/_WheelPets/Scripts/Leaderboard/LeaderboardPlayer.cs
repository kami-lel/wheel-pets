using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;

public class LeaderboardPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject userScore;

    [SerializeField]
    private GameObject stats;

    [SerializeField]
    private GameObject petContainer; // Container for the pet visualization

    [SerializeField]
    private GameObject petPrefab; // Prefab for the pet model

    [SerializeField]
    private LocalizeStringEvent rankText;

    [SerializeField]
    private TextMeshProUGUI nameText;

    [SerializeField]
    private LocalizeStringEvent pointsText;

    [SerializeField]
    private LocalizeStringEvent drivingText;

    [SerializeField]
    private LocalizeStringEvent minigamesText;

    private GameObject currentPet; // Reference to the instantiated pet

    public void LoadPlayerData(int userRank)
    {
        PlayerData data = Data.GetPlayerData();

        // Ensure userScore and stats are assigned
        if (userScore == null || stats == null)
        {
            Debug.LogError("userScore or stats GameObject is not assigned.");
            return;
        }

        // Update rank text
        if (rankText != null)
        {
            rankText.StringReference.Arguments = new object[] { userRank };
            rankText.RefreshString();
        }

        // Update name text
        if (nameText != null)
        {
            nameText.text = data.playerName;
        }

        // Update points text
        if (pointsText != null)
        {
            int totalPoints = data.drivingPoint + data.minigamePoints;
            pointsText.StringReference.Arguments = new object[] { totalPoints };
            pointsText.RefreshString();
        }

        // Update driving stats text
        if (drivingText != null)
        {
            drivingText.StringReference.Arguments = new object[] { data.drivingPoint };
            drivingText.RefreshString();
        }

        // Update minigame stats text
        if (minigamesText != null)
        {
            minigamesText.StringReference.Arguments = new object[] { data.minigamePoints };
            minigamesText.RefreshString();
        }

        // Load and display the pet
        LoadPet(data);
    }

    private void LoadPet(PlayerData data)
    {
        // Clean up any existing pet
        if (currentPet != null)
        {
            Destroy(currentPet);
        }

        // Check if we have the necessary components
        if (petContainer == null || petPrefab == null)
        {
            Debug.LogError("Pet container or prefab is not assigned.");
            return;
        }

        // Instantiate the pet prefab
        currentPet = Instantiate(petPrefab, petContainer.transform);
        
        // Apply pet customizations from player data
        PetCustomization petCustomization = currentPet.GetComponent<PetCustomization>();
        if (petCustomization != null)
        {
            petCustomization.ApplyCustomization(data.petCustomization);
        }
    }
}
