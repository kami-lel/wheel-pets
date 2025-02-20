using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField]
    private GameObject leaderboardEntryPrefab;

    [SerializeField]
    private Transform entryContainer;

    [SerializeField]
    private LeaderboardPlayer leaderboardPlayer;

    private List<LeaderboardEntry> leaderboardEntries =
        new List<LeaderboardEntry>();

    private PlayerData playerData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        playerData = Data.GetPlayerData();

        // add other players' data into leaderboard
        foreach (
            PlayerData.LeaderboardOtherPlayerData otherPlayer in playerData.leaderBoardOtherPlayerData
        )
        {
            LeaderboardEntry entry = new(otherPlayer.name, otherPlayer.point);
            leaderboardEntries.Add(entry);
        }

        // add our player's data into leaderboard
        LeaderboardEntry playerEntry = new(
            playerData.playerName,
            playerData.drivingPoint
        );
        leaderboardEntries.Add(playerEntry);
        PopulateLeaderboardUI();
    }

    public void ClickBackButton()
    {
        SceneChange.LoadTitle();
    }

    private void PopulateLeaderboardUI()
    {
        var sortedEntries = leaderboardEntries
            .OrderByDescending(entry => entry.score)
            .ToList();

        foreach (Transform child in entryContainer)
        {
            Destroy(child.gameObject);
        }

        int userRank = 0;

        for (int i = 0; i < sortedEntries.Count; i++)
        {
            sortedEntries[i].rank = i + 1;

            if (sortedEntries[i].playerName == playerData.playerName)
            {
                userRank = sortedEntries[i].rank;
            }

            GameObject newEntry = Instantiate(
                leaderboardEntryPrefab,
                entryContainer
            );
            Transform leaderboardContent = newEntry.transform.Find(
                "LeaderboardContent"
            );
            leaderboardContent
                .Find("RankText")
                .GetComponent<TextMeshProUGUI>()
                .text = "#" + sortedEntries[i].rank.ToString();
            leaderboardContent
                .Find("NameText")
                .GetComponent<TextMeshProUGUI>()
                .text = sortedEntries[i].playerName;
            leaderboardContent
                .Find("ScoreText")
                .GetComponent<TextMeshProUGUI>()
                .text = sortedEntries[i].score.ToString() + " Points";
        }

        leaderboardPlayer.LoadPlayerData(userRank);
    }

    private void OnApplicationQuit()
    {
        Data.SavePlayerDataToFile();
    }
}
