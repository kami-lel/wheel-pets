using UnityEngine;

public class RestartConfirmContainer : MonoBehaviour
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
            Debug.Log("PauseOverlay\tRestartConfirm Screen Shown");
        }

        pauseOverlay.StopMinigameTimeAndAudio();
        pauseOverlay.status = PauseOverlay.Status.RestartConfirm;
    }

    public void OnClickConfirmButton()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tRestart Game from RestartConfirm Screen");
        }
        pauseOverlay.ReloadMinigameScene();
    }

    public void OnClickResumeButton()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tResume Game from RestartConfirm Screen");
        }

        pauseOverlay.ContinueMinigameTimeAndAudio();
        pauseOverlay.status = PauseOverlay.Status.Running;
        gameObject.SetActive(false);
    }
}
