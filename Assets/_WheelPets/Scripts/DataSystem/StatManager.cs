using System;
using UnityEngine;

[Serializable]
public class MinigameStatistics
{
    /// <summary>
    /// Records a win for the minigame and updates the best score if the
    /// current score is better. This function can be called in the actual
    /// minigame logic to register a win.
    /// </summary>
    /// <param name="currentScore">The score achieved in this win.</param>
    /// <returns>Whether a new best score has been set.</returns>
    /// <returns><c>true</c> if a new best score is set, otherwise <c>false</c>.</returns>
    public bool RecordWin(float currentScore)
    {
        bool updateResult = UpdateBestScore(currentScore);
        winCount++;
        coinsAccumulated += Data.pointCoinManager.WinMinigame();
        DebugPrintRecord(true, currentScore, updateResult);
        return updateResult;
    }

    /// <summary>
    /// Records a loss for the minigame and updates the best score if the
    /// current score is better. This function can be called in the actual
    /// minigame logic to register a loss.
    /// </summary>
    /// <param name="currentScore">The score achieved in this loss.</param>
    /// <returns>Whether a new best score has been set.</returns>
    /// <returns><c>true</c> if a new best score is set, otherwise <c>false</c>.</returns>
    public bool RecordLose(float currentScore)
    {
        bool updateResult = UpdateBestScore(currentScore);
        loseCount++;
        coinsAccumulated += Data.pointCoinManager.LoseMinigame();
        DebugPrintRecord(false, currentScore, updateResult);
        return updateResult;
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

    /// <summary>
    /// The best score ever achieved in this minigame.
    /// </summary>
    public float bestScore = 0f;

    /// <summary>
    /// The total amount of coins collected from this minigame.
    /// </summary>
    public int coinsAccumulated = 0;

    private readonly string minigameName;
    private readonly bool isBestScoreReversed;

    /// <summary>
    /// Initializes a new instance of the <see cref="MinigameStatistics"/> class.
    /// This constructor allows the specification of score comparison behavior.
    ///
    /// <para>
    /// If <paramref name="isBestScoreReversed"/> is set to <c>false</c>,
    /// a higher score is considered better (e.g., high score in traditional
    /// games). If set to <c>true</c>, a lower score indicates better
    /// performance (e.g., best time in time-based challenges).
    /// </para>
    /// </summary>
    /// <param name="minigameName">
    /// The name of the minigame, utilized in debug print statements
    /// for tracking and displaying statistics related to this specific
    /// game session.
    /// </param>
    /// <param name="isBestScoreReversed">
    /// Determines the comparison method for scores.
    /// </param>
    public MinigameStatistics(
        string minigameName,
        bool isBestScoreReversed = false
    )
    {
        this.minigameName = minigameName;
        this.isBestScoreReversed = isBestScoreReversed;
    }

    private bool UpdateBestScore(float currentScore)
    {
        // no best score ever set
        if (PlayCount() == 0)
        {
            bestScore = currentScore;
            return true;
        }

        if (isBestScoreReversed)
        {
            // lower value, score is better
            if (currentScore < bestScore)
            {
                bestScore = currentScore;
                return true;
            }
        }
        else
        {
            // higher value, score is better
            if (currentScore > bestScore)
            {
                bestScore = currentScore;
                return true;
            }
        }

        // does not update the best score
        return false;
    }

    private void DebugPrintRecord(
        bool isWin,
        float currentScore,
        bool updateResult
    )
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log(
                $"Stat\t{minigameName}\t"
                    + "Record "
                    + (isWin ? "Win" : "Loss")
                    + " "
                    + $"win={winCount} loss={loseCount} "
                    + (
                        updateResult
                            ? $"New Best Score:{bestScore}"
                            : $"current score={currentScore} best={bestScore}"
                    )
            );
        }
    }
}
