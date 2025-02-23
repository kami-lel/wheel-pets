using System;
using UnityEngine;

// fixme need ui re-design
public class PauseContainer : MonoBehaviour
{
    private PauseOverlay pauseOverlay;

    private void Awake()
    {
        pauseOverlay = FindFirstObjectByType<PauseOverlay>();
    }

    private void OnEnable()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tPause Screen Shown");
        }
        pauseOverlay.StopMinigameTimeAndAudio();
        pauseOverlay.minigameStatus = PauseOverlay.MinigameStatus.Paused;
    }

    public void OnClickResumeButton()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tGame Resumed");
        }

        pauseOverlay.ContinueMinigameTimeAndAudio();
        pauseOverlay.minigameStatus = PauseOverlay.MinigameStatus.Running;
        gameObject.SetActive(false);
    }

    public void OnClickExitButton()
    {
        pauseOverlay.ContinueMinigameTimeAndAudio();
        SceneChange.LoadSelector();
    }

    public void VolumeSliderOnValueChanged(Single value)
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log($"PauseOverlay\tmain volume changed to {value}");
        }
        // BUG volume slider not working
    }
}
