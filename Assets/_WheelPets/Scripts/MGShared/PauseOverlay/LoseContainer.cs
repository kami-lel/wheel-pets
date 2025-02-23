using UnityEngine;

// fixme need ui re-design
public class LoseContainer : MonoBehaviour
{
    [SerializeField]
    private PauseOverlay pauseOverlay;

    public void OnClickRestartButton()
    {
        // TODO
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
