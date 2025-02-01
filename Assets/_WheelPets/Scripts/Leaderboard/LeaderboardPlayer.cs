using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPlayer : MonoBehaviour
{
    [SerializeField] private GameObject userScore;
    [SerializeField] private GameObject stats;

    private void Start()
    {
        // LoadPlayerData will be called by LeaderboardManager with the correct rank
    }

    public void LoadPlayerData(int userRank)
    {
        PlayerData data = PlayerData.Data;

        // Ensure userScore and stats are assigned
        if (userScore == null || stats == null)
        {
            Debug.LogError("userScore or stats GameObject is not assigned.");
            return;
        }

        // Update userScore texts
        Text placeText = userScore.transform.Find("Place").GetComponent<Text>();
        Text nameText = userScore.transform.Find("Name").GetComponent<Text>();
        Text pointsText = userScore.transform.Find("Points").GetComponent<Text>();

        if (placeText == null || nameText == null || pointsText == null)
        {
            Debug.LogError("One or more Text components are not assigned in userScore.");
            return;
        }

        placeText.text = "#" + userRank.ToString();
        nameText.text = data.playerName;
        pointsText.text = data.drivingPoint.ToString() + " Points";

        // Update stats texts
        Text drivingStatsText = stats.transform.Find("DrivingStats").GetComponent<Text>();
        Text minigameStatsText = stats.transform.Find("MinigameStats").GetComponent<Text>();

        if (drivingStatsText == null || minigameStatsText == null)
        {
            Debug.LogError("One or more Text components are not assigned in stats.");
            return;
        }

        drivingStatsText.text = "Miles: " + data.drivingMiles.ToString();
        minigameStatsText.text = "Minigame Stats: " + GetMinigameStats(data);
    }

    private string GetMinigameStats(PlayerData data)
    {
        return $"Bath: {data.statBath.playCount}/{data.statBath.winCount}, " +
               $"Feed: {data.statFeed.playCount}/{data.statFeed.winCount}, " +
               $"Fetch: {data.statFetch.playCount}/{data.statFetch.winCount}, " +
               $"HideNSeek: {data.statHideNSeek.playCount}/{data.statHideNSeek.winCount}, " +
               $"TugOWar: {data.statTugOWar.playCount}/{data.statTugOWar.winCount}, " +
               $"WalkScene: {data.statWalkScene.playCount}/{data.statWalkScene.winCount}";
    }
}
