using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization.Components; // Add this line

public class LeaderboardPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject userScore;

    [SerializeField]
    private GameObject stats;

    [SerializeField]
    private LocalizedLeaderboardText localizedLeaderboardText; // Reference to the LocalizedLeaderboardText script

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
        LocalizeStringEvent pointsTextEvent = userScore
            .transform.Find("Points")
            .GetComponent<LocalizeStringEvent>();

        if (placeText == null || nameText == null || pointsTextEvent == null)
        {
            Debug.LogError(
                "One or more Text components are not assigned in userScore."
            );
            return;
        }

        placeText.text = "#" + userRank.ToString();
        nameText.text = data.playerName;
        localizedLeaderboardText.UpdatePointsText(data.drivingPoint);

        // Update stats texts
        LocalizeStringEvent drivingStatsTextEvent = stats
            .transform.Find("Driving Stats")
            .GetComponent<LocalizeStringEvent>();
        LocalizeStringEvent minigameStatsTextEvent = stats
            .transform.Find("Minigame Stats")
            .GetComponent<LocalizeStringEvent>();

        if (drivingStatsTextEvent == null || minigameStatsTextEvent == null)
        {
            Debug.LogError(
                "One or more Text components are not assigned in stats."
            );
            return;
        }

        localizedLeaderboardText.UpdateDrivingStatsText(data);
        localizedLeaderboardText.UpdateMinigameStatsText(data);
    }
}
