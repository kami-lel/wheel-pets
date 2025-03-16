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
                data.timesParkedWithoutBraking,
                data.stopSignsStoppedAt,
            };
            drivingStatsTextEvent.RefreshString();
        }
    }

    public void UpdateMinigameStatsText(PlayerData data)
    {
        if (minigameStatsTextEvent != null)
        {
            var stats = data.GetAllStats();
            minigameStatsTextEvent.StringReference.Arguments = new object[]
            {
                stats["tug"].winCount,
                stats["bath"].PlayCount(),
                stats["hide"].winCount,
                data.purchasedAccessories.Count
            };
            minigameStatsTextEvent.RefreshString();
        }
    }
}
