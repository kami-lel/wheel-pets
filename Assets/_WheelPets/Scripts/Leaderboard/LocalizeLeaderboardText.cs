using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class LocalizedLeaderboardText : MonoBehaviour
{
    public LocalizeStringEvent pointsTextEvent;
    public LocalizeStringEvent drivingStatsTextEvent;
    public LocalizeStringEvent minigameStatsTextEvent;

    public void UpdatePointsText(int points)
    {
        if (pointsTextEvent != null)
        {
            pointsTextEvent.StringReference.Arguments = new object[]
            {
                points,
            };
            pointsTextEvent.RefreshString();
        }
    }

    public void UpdateDrivingStatsText(PlayerData data)
    {
        if (drivingStatsTextEvent != null)
        {
            drivingStatsTextEvent.StringReference.Arguments = new object[]
            {
                data.leftTurnSignals,
                data.rightTurnSignals,
                data.timesParkedWithoutTouchingLines,
                data.stopSignsStoppedAt,
            };
            drivingStatsTextEvent.RefreshString();
        }
    }

    public void UpdateMinigameStatsText(PlayerData data)
    {
        if (minigameStatsTextEvent != null)
        {
            minigameStatsTextEvent.StringReference.Arguments = new object[]
            {
                // BUG these data fields are deprecated
                data.tugOfWarGamesWon,
                data.timesPetWashed,
                data.timesHideNSeekWon,
                data.cosmeticsUnlocked,
            };
            minigameStatsTextEvent.RefreshString();
        }
    }
}
