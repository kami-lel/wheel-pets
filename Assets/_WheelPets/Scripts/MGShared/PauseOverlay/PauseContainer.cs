using UnityEngine;

// fixme need ui re-design
public class PauseContainer : MonoBehaviour
{
    [SerializeField]
    private PauseOverlay pauseOverlay;

    private void OnEnable()
    {
        pauseOverlay.StopMinigameTimeAndAudio();
    }

    public void OnClickResumeButton()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tGame Resumed");
        }

        pauseOverlay.ContinueMinigameTimeAndAudio();
        gameObject.SetActive(false);
    }

    public void OnClickExitButton()
    {
        pauseOverlay.ContinueMinigameTimeAndAudio();
        SceneChange.LoadSelector();
    }

    public void VolumeSliderOnValueChanged(System.Single value)
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log($"PauseOverlay\tmain volume changed to {value}");
        }
        // BUG volume slider not working
    }
}
