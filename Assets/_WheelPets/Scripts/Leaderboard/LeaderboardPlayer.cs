using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject userScore;

    [SerializeField]
    private GameObject stats;

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
        pointsText.text = data.drivingPoint.ToString() + " Points";

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

        drivingStatsText.text =
            $"Left Turn Signals: {data.leftTurnSignals}\n"
            + $"Right Turn Signals: {data.rightTurnSignals}\n"
            + $"Times Parked Without Touching Lines: {data.timesParkedWithoutTouchingLines}\n"
            + $"Stop Signs Stopped At: {data.stopSignsStoppedAt}";

        minigameStatsText.text =
            $"Tug Of War Games Won: {data.tugOfWarGamesWon}\n"
            + $"Times Pet Washed: {data.timesPetWashed}\n"
            + $"Times Hide-N-Seek Won: {data.timesHideNSeekWon}\n"
            + $"Cosmetics Unlocked: {data.cosmeticsUnlocked}\n"
            + $"Fetch High Score: {data.fetchHighScore}\n"
            + $"Best Time for Bath Minigame: {data.bathMinigameBestTime:F2} seconds";
    }
}
