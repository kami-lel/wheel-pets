using UnityEngine;

// fixme need ui re-design
// todo linked with game stat
public class WinContainer : MonoBehaviour
{
    [SerializeField]
    private PauseOverlay pauseOverlay; // FIXME dynamically get

    public void OnEnable()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tWin Screen Shown");
        }
        pauseOverlay.minigameStatus = PauseOverlay.MinigameStatus.Won;
    }

    public void OnClickRestartButton()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tRestart Game from Win Screen");
        }

        pauseOverlay.ReloadMinigameScene();
    }

    public void OnClickExitButton()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tExit Game from Win Screen");
        }

        SceneChange.LoadSelector();
    }
}
