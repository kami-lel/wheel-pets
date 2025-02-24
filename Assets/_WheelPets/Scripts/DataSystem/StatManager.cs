using System;

// TODO add high score
// FIXME makesure these are connected with the game

public class MinigameStatistics
{
    public int playCount = 0; { get; private set; }
    public int winCount = 0; { get; private set; }
    public float highScore = 0f; { get; private set; }

    public string highScoreUnit { get; private set; }
    private bool isHighScoreReversed; // determine high score direction

    public MinigameStatistics(
        string highScoreUnit = "Point",
        bool isHighScoreReversed = false
    )
    {
        this.highScoreUnit = highScoreUnit;
        this.isHighScoreReversed = isHighScoreReversed;
    }

    public void RecordWin()
    {
        playCount++;
        winCount++;
    }

    public void RecordLose()
    {
        playCount++;
    }
}
