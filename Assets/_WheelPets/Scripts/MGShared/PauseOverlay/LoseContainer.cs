using UnityEngine;

// FIXME need ui re-design
// TODO linked with game stat
public class LoseContainer : MonoBehaviour
{
    private PauseOverlay pauseOverlay;

    private void Awake()
    {
        pauseOverlay = FindFirstObjectByType<PauseOverlay>();
    }

    public void OnEnable()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tLose Screen Shown");
        }
        pauseOverlay.status = PauseOverlay.Status.Lost;
    }

    public void OnClickRestartButton()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tRestart Game from Lose Screen");
        }
        pauseOverlay.ReloadMinigameScene();
    }

    public void OnClickExitButton()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tExit Game from Lose Screen");
        }

        SceneChange.LoadSelector();
    }
}
