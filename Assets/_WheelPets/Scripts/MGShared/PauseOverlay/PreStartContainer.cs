using UnityEngine;

public class PreStartContainer : MonoBehaviour
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
            Debug.Log("PauseOverlay\tPreStart Screen Shown");
        }

        pauseOverlay.StopMinigameTimeAndAudio();
        pauseOverlay.minigameStatus = PauseOverlay.MinigameStatus.PreStart;
    }

    public void OnClickStartButton()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tStart Game from PreStart Screen");
        }

        pauseOverlay.ContinueMinigameTimeAndAudio();
        pauseOverlay.minigameStatus = PauseOverlay.MinigameStatus.Running;
        gameObject.SetActive(false);
    }
}
