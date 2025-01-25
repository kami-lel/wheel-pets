[System.Serializable]
public class LeaderboardEntry
{
    public int rank;
    public string playerName;
    public int score;

    public LeaderboardEntry(int rank, string playerName, int score)
    {
        this.rank = rank;
        this.playerName = playerName;
        this.score = score;
    }
}
