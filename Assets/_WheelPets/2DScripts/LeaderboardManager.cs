using System.Collections.Generic;
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
        // clear entries before refilling
        foreach (Transform child in leaderboardContent)
        {
            Destroy(child.gameObject);
        }

        // add new entries
        foreach (var entry in leaderboardEntries)
        {
            GameObject newEntry = Instantiate(leaderboardEntryPrefab, leaderboardContent);
            
        }
    }
}
