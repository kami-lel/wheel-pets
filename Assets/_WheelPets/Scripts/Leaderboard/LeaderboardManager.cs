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
    private LeaderboardEntry player;

    [SerializeField]
    private LeaderboardLargePanel largePanel;

    private List<LeaderboardEntry> leaderboardEntries = new List<LeaderboardEntry>();

    private PlayerData playerData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        playerData = PlayerData.LoadFromFile();

        for (int i = 0; i < 5; i++)
        {
            PlayerData.LeaderboardOtherPlayerData otherPlayer =
                playerData.leaderBoardOtherPlayerData[i];

            LeaderboardEntry entry = new LeaderboardEntry(otherPlayer.name, otherPlayer.point);
            leaderboardEntries.Add(entry);
        }

        player = new LeaderboardEntry(playerData.playerName, playerData.drivingPoint);
        leaderboardEntries.Add(player);
        PopulateLeaderboardUI();
    }

    private void PopulateLeaderboardUI()
    {
        // sort entries by rank
        var sortedEntries = leaderboardEntries.OrderByDescending(entry => entry.score).ToList();

        // clear entries before refilling
        foreach (Transform child in entryContainer)
        {
            Destroy(child.gameObject);
        }

        // add new entries
        for (int i = 0; i < sortedEntries.Count; i++)
        {
            // assigns entry rank
            sortedEntries[i].rank = i + 1;

            GameObject newEntry = Instantiate(leaderboardEntryPrefab, entryContainer);
            newEntry
                .transform.Find("LeaderboardContent")
                .GetComponent<HorizontalLayoutGroup>()
                .enabled = true;
            newEntry
                .transform.Find("LeaderboardContent/RankText")
                .GetComponent<TextMeshProUGUI>()
                .text = "#" + sortedEntries[i].rank.ToString();
            newEntry
                .transform.Find("LeaderboardContent/NameText")
                .GetComponent<TextMeshProUGUI>()
                .text = sortedEntries[i].playerName + ": ";
            newEntry
                .transform.Find("LeaderboardContent/ScoreText")
                .GetComponent<TextMeshProUGUI>()
                .text = sortedEntries[i].score.ToString() + " Points";
        }

        // update large panel
        largePanel.LoadPlayerData();
    }

    public void AddEntry(string playerName, int score)
    {
        leaderboardEntries.Add(new LeaderboardEntry(playerName, score));
        PopulateLeaderboardUI();
    }

    public LeaderboardEntry GetPlayer()
    {
        return player;
    }

    private void OnApplicationQuit()
    {
        PlayerData.SaveToFile();
    }
}
