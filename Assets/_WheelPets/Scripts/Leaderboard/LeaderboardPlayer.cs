using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPlayer : MonoBehaviour
{
    [SerializeField] private Text playerNameText;
    [SerializeField] private Text drivingMilesText;
    [SerializeField] private Text gamePointsText;
    [SerializeField] private Text minigameStatsText;

    private void Start()
    {
        LoadPlayerData();
    }

    public void LoadPlayerData()
    {
        PlayerData data = PlayerData.Data;
        playerNameText.text = data.playerName;
        drivingMilesText.text = "Miles: " + data.drivingMiles.ToString();
        gamePointsText.text = "Game Points: " + data.gamePoint.ToString();
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
