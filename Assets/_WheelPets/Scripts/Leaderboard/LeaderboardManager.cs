using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField]
    private GameObject leaderboardEntryPrefab;

    [SerializeField]
    private Transform entryContainer;

    [SerializeField]
    private LeaderboardPlayer leaderboardPlayer;

    private List<LeaderboardEntry> leaderboardEntries = new List<LeaderboardEntry>();

    private PlayerData playerData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        playerData = PlayerData.Data;

        for (int i = 0; i < playerData.leaderBoardOtherPlayerData.Length; i++)
        {
            PlayerData.LeaderboardOtherPlayerData otherPlayer = playerData.leaderBoardOtherPlayerData[i];
            LeaderboardEntry entry = new LeaderboardEntry(otherPlayer.name, otherPlayer.point);
            leaderboardEntries.Add(entry);
        }

        LeaderboardEntry playerEntry = new LeaderboardEntry(playerData.playerName, playerData.drivingPoint);
        leaderboardEntries.Add(playerEntry);
        PopulateLeaderboardUI();
    }

    private void PopulateLeaderboardUI()
    {
        var sortedEntries = leaderboardEntries.OrderByDescending(entry => entry.score).ToList();

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

            GameObject newEntry = Instantiate(leaderboardEntryPrefab, entryContainer);
            Transform leaderboardContent = newEntry.transform.Find("LeaderboardContent");
            leaderboardContent.Find("RankText").GetComponent<TextMeshProUGUI>().text = "#" + sortedEntries[i].rank.ToString();
            leaderboardContent.Find("NameText").GetComponent<TextMeshProUGUI>().text = sortedEntries[i].playerName;
            leaderboardContent.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = sortedEntries[i].score.ToString() + " Points";
        }

        leaderboardPlayer.LoadPlayerData(userRank);
    }
}
