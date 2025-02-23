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
        pauseOverlay.status = PauseOverlay.Status.PreStart;
    }

    public void OnClickStartButton()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tStart Game from PreStart Screen");
        }

        pauseOverlay.ContinueMinigameTimeAndAudio();
        pauseOverlay.status = PauseOverlay.Status.Running;
        gameObject.SetActive(false);
    }
}
