[System.Serializable]
public class LeaderboardEntry
{
    public int rank;
    public string playerName;
    public int score;

    public LeaderboardEntry(string playerName, int score)
    {
        this.rank = 0;
        this.playerName = playerName;
        this.score = score;
    }
}
