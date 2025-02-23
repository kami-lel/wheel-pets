using UnityEngine;

// fixme need ui re-design
// todo linked with game stat
public class LoseContainer : MonoBehaviour
{
    [SerializeField]
    private PauseOverlay pauseOverlay;

    public void OnEnable()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tLose Screen Shown");
        }
        pauseOverlay.minigameStatus = PauseOverlay.MinigameStatus.Lost;
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
