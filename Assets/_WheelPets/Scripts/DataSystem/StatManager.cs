using System;

// FIXME makesure these are connected with the game

public class MinigameStatistics
{
    public void RecordWin()
    {
        playCount++;
        winCount++;
    }

    public void RecordLose()
    {
        playCount++;
    }

    public int playCount = 0; { get; private set; }
    public int winCount = 0; { get; private set; }
    public float bestScore = 0f; { get; private set; }

    public string bestScoreUnit { get; private set; }
    private bool isBestScoreReversed; // determine high score direction

    public MinigameStatistics(
        string bestScoreUnit = "Point",
        bool isBestScoreReversed = false
    )
    {
        this.bestScoreUnit = bestScoreUnit;
        this.isBestScoreReversed = isBestScoreReversed;
    }

}
