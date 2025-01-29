using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private GameObject leaderboardEntryPrefab;
    [SerializeField] private Transform entryContainer;

    private List<LeaderboardEntry> leaderboardEntries = new List<LeaderboardEntry>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        leaderboardEntries.Add(new LeaderboardEntry("Player1", 10000));
        leaderboardEntries.Add(new LeaderboardEntry("Player2", 9000));
        leaderboardEntries.Add(new LeaderboardEntry("Player3", 8000));
        leaderboardEntries.Add(new LeaderboardEntry("Player4", 7000));
        leaderboardEntries.Add(new LeaderboardEntry("Player5", 6500));
        leaderboardEntries.Add(new LeaderboardEntry("UserName", 5204));
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
            GameObject newEntry = Instantiate(leaderboardEntryPrefab, entryContainer);
            newEntry.transform.Find("LeaderboardContent").GetComponent<HorizontalLayoutGroup>().enabled = true;
            newEntry.transform.Find("LeaderboardContent/RankText").GetComponent<TextMeshProUGUI>().text = "#" + (i + 1).ToString();
            newEntry.transform.Find("LeaderboardContent/NameText").GetComponent<TextMeshProUGUI>().text = sortedEntries[i].playerName + ": ";
            newEntry.transform.Find("LeaderboardContent/ScoreText").GetComponent<TextMeshProUGUI>().text = sortedEntries[i].score.ToString() + " Points";
        }
    }

    public void AddEntry(string playerName, int score)
    {
        leaderboardEntries.Add(new LeaderboardEntry(playerName, score));
        PopulateLeaderboardUI();
    }
}
