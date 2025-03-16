using UnityEngine;
using UnityEngine.UI;

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

        // Update userScore texts
        Text placeText = userScore
            .transform.Find("Place")
            .GetComponent<Text>();
        Text nameText = userScore.transform.Find("Name").GetComponent<Text>();
        Text pointsText = userScore
            .transform.Find("Points")
            .GetComponent<Text>();

        if (placeText == null || nameText == null || pointsText == null)
        {
            Debug.LogError(
                "One or more Text components are not assigned in userScore."
            );
            return;
        }

        placeText.text = "#" + userRank.ToString();
        nameText.text = data.playerName;
        
        // Calculate total points (driving + minigame points)
        int totalPoints = data.drivingPoint + data.minigamePoints;
        pointsText.text = totalPoints.ToString() + " Points";

        // Update stats texts
        Text drivingStatsText = stats
            .transform.Find("Driving Stats")
            .GetComponent<Text>();
        Text minigameStatsText = stats
            .transform.Find("Minigame Stats")
            .GetComponent<Text>();

        if (drivingStatsText == null || minigameStatsText == null)
        {
            Debug.LogError(
                "One or more Text components are not assigned in stats."
            );
            return;
        }

        // Update driving stats with the new "parked without braking" stat
        drivingStatsText.text =
            $"Left Turn Signals: {data.leftTurnSignals}\n"
            + $"Right Turn Signals: {data.rightTurnSignals}\n"
            + $"Times Parked Without Braking: {data.timesParkedWithoutBraking}\n"
            + $"Stop Signs Stopped At: {data.stopSignsStoppedAt}";

        // Update minigame stats with the new stat system
        minigameStatsText.text =
            $"Minigames Completed: {data.minigamesCompleted}\n"
            + $"Total Minigame Wins: {data.totalMinigameWins}\n"
            + $"Best Scores:\n"
            + $"  Fetch: {data.fetchHighScore}\n"
            + $"  Bath Time: {data.bathMinigameBestTime:F2}s\n"
            + $"  Hide-N-Seek: {data.hideNSeekBestTime:F2}s\n"
            + $"  Tug of War: {data.tugOfWarBestScore}";

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
