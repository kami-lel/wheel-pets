using UnityEngine;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.Settings;

public class LeaderboardPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject userScore;

    [SerializeField]
    private GameObject stats;

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

    private GameObject currentPet;

    [SerializeField]
    private GameObject petContainer;

    [SerializeField]
    private GameObject petPrefab;

    public void LoadPlayerData(int userRank)
    {
        PlayerData data = Data.GetPlayerData();

        // Ensure required components are assigned
        if (userScore == null || stats == null)
        {
            Debug.LogError("userScore or stats GameObject is not assigned.");
            return;
        }

        // Update rank text
        if (rankText != null)
        {
            rankText.StringReference.TableReference = "UI";
            rankText.StringReference.TableEntryReference = "leaderboard_rank";
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
            pointsText.StringReference.TableReference = "UI";
            pointsText.StringReference.TableEntryReference = "leaderboard_points";
            pointsText.StringReference.Arguments = new object[] { data.drivingPoint + data.minigameCoin };
            pointsText.RefreshString();
        }

        // Update driving stats text
        if (drivingText != null)
        {
            drivingText.StringReference.TableReference = "UI";
            drivingText.StringReference.TableEntryReference = "leaderboard_driving_stats";
            drivingText.StringReference.Arguments = new object[] 
            { 
                data.leftTurnSignals,
                data.rightTurnSignals,
                data.timesParkedWithoutBraking,
                data.stopSignsStoppedAt
            };
            drivingText.RefreshString();
        }

        // Update minigame stats text
        if (minigamesText != null)
        {
            var stats = data.GetAllStats();
            minigamesText.StringReference.TableReference = "UI";
            minigamesText.StringReference.TableEntryReference = "leaderboard_minigame_stats";
            minigamesText.StringReference.Arguments = new object[]
            {
                stats["tug"].winCount,
                stats["bath"].PlayCount(),
                stats["hide"].winCount,
                data.purchasedAccessories.Count
            };
            minigamesText.RefreshString();
        }

        // Load pet if one has been adopted
        LoadPet(data);
    }

    private void LoadPet(PlayerData data)
    {
        if (data.petData != null && petContainer != null && petPrefab != null)
        {
            // Remove existing pet if any
            if (currentPet != null)
            {
                Destroy(currentPet);
            }

            // Create new pet
            currentPet = Instantiate(petPrefab, petContainer.transform);
            
            // Apply customization if interface is implemented
            var customization = currentPet.GetComponent<IPetCustomization>();
            if (customization != null)
            {
                customization.ApplyCustomization(data.petData);
            }
        }
    }
}
