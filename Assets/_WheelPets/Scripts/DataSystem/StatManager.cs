using System;

// FIXME makesure these are connected with the game

public class MinigameStatistics
{
    public bool RecordWin(float currentScore)
    {
        playCount++;
        winCount++;
        return UpdateBestScore(currentScore);
    }

    public bool RecordLose(float currentScore)
    {
        playCount++;
        return UpdateBestScore(currentScore);
    }

    public int playCount = 0;
    public int winCount = 0;
    public float bestScore = 0f;

    public string bestScoreUnit;
    private readonly bool isBestScoreReversed;

    public MinigameStatistics(string bestScoreUnit = "Point", bool isBestScoreReversed = false)
    {
        this.bestScoreUnit = bestScoreUnit;
        this.isBestScoreReversed = isBestScoreReversed;
    }

    private bool UpdateBestScore(float currentScore)
    {
        if (isBestScoreReversed)
        {
            if (currentScore < bestScore)
            {
                bestScore = currentScore;
                return true;
            }
        }
        else
        {
            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                return true;
            }
        }
        return false;
    }
}
