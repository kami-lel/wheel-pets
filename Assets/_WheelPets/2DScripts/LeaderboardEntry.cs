[System.Serializable]
public class LeaderboardEntry
{
    public string playerName;
    public int value;

    public LeaderboardEntry(string playerName, int value)
    {
        this.playerName = playerName;
        this.value = value;
    }
}
