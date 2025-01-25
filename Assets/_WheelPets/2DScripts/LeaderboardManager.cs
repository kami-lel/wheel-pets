using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private GameObject leaderboardEntryPrefab;
    [SerializeField] private Transform leaderboardContent;

    private List<LeaderboardEntry> leaderboardEntries = new List<LeaderboardEntry>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        PopulateLeaderboardUI();
    }

    private void PopulateLeaderboardUI()
    {
        // sort entries by rank
        leaderboardEntries = leaderboardEntries.OrderByDescending(entry => entry.score).ToList();

        // clear entries before refilling
        foreach (Transform child in leaderboardContent)
        {
            Destroy(child.gameObject);
        }

        // add new entries
        foreach (var entry in leaderboardEntries)
        {
            GameObject newEntry = Instantiate(leaderboardEntryPrefab, leaderboardContent);
            newEntry.transform.Find("RankText").GetComponent<Text>().text = entry.rank.ToString();
            newEntry.transform.Find("NameText").GetComponent<Text>().text = entry.playerName;
            newEntry.transform.Find("ScoreText").GetComponent<Text>().text = entry.score.ToString();
        }
    }
}
