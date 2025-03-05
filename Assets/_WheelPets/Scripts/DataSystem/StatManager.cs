using System;

public class MinigameStatistics
{
    /// <summary>
    /// Records a win for the minigame and updates the best score if the current score is better.
    /// This function can be called in the actual minigame logic to register a win.
    /// </summary>
    /// <param name="currentScore">The score achieved in this win.</param>
    /// <returns>Whether a new best score has been set.</returns>
    /// <returns><c>true</c> if a new best score is set, otherwise <c>false</c>.</returns>
    public bool RecordWin(float currentScore)
    {
        winCount++;
        return UpdateBestScore(currentScore);
    }

    /// <summary>
    /// Records a loss for the minigame and updates the best score if the current score is better.
    /// This function can be called in the actual minigame logic to register a loss.
    /// </summary>
    /// <param name="currentScore">The score achieved in this loss.</param>
    /// <returns>Whether a new best score has been set.</returns>
    /// <returns><c>true</c> if a new best score is set, otherwise <c>false</c>.</returns>
    public bool RecordLose(float currentScore)
    {
        loseCount++;
        return UpdateBestScore(currentScore);
    }

    /// <summary>
    /// Returns the total play count by summing win and lose counts.
    /// </summary>
    /// <returns>The total number of games played.</returns>
    public int PlayCount()
    {
        return winCount + loseCount;
    }

    /// <summary>
    /// The count of games won.
    /// </summary>
    public int winCount = 0;

    /// <summary>
    /// The count of games lost.
    /// </summary>
    public int loseCount = 0;

    public float bestScore = 0f;

    private readonly bool isBestScoreReversed;

    /// <summary>
    /// Initializes a new instance of the <see cref="MinigameStatistics"/> class.
    /// This constructor allows the specification of score comparison behavior.
    ///
    /// <para>
    /// If <paramref name="isBestScoreReversed"/> is set to <c>false</c>,
    /// a higher score is considered better (e.g., high score in traditional games).
    /// If set to <c>true</c>, a lower score indicates better performance
    /// (e.g., best time in time-based challenges).
    /// </para>
    /// </summary>
    /// <param name="isBestScoreReversed">Determines the comparison method for scores.</param>
    public MinigameStatistics(bool isBestScoreReversed = false)
    {
        this.isBestScoreReversed = isBestScoreReversed;
    }

    private bool UpdateBestScore(float currentScore)
    {
        // BUG not init
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
