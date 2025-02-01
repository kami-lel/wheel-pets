using UnityEngine;
using UnityEngine.UI;

public class LeaderboardLargePanel : MonoBehaviour
{
    [SerializeField] private LeaderboardManager leaderboardManager;
    [SerializeField] private GameObject largePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private LeaderboardEntry playerData;
    void Start()
    {
        
    }

    public void LoadPlayerData()
    {
        playerData = leaderboardManager.GetPlayer();
        largePanel.transform.Find("Place").GetComponent<Text>().text = "#" + playerData.rank.ToString();
        largePanel.transform.Find("Name").GetComponent<Text>().text = playerData.playerName;
        largePanel.transform.Find("Points").GetComponent<Text>().text = playerData.score.ToString() + " Points";
    }
}
