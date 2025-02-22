using UnityEngine;

public class PauseContainer : MonoBehaviour
{
    [SerializeField]
    private PauseOverlay pauseOverlay;

    private void OnEnable()
    {
        pauseOverlay.minigameStage = PauseOverlay.MinigameStage.Paused;

        // stop game time
        Time.timeScale = 0f;
        // BUG currently it doesn't stop sound & bgm
    }

    public void OnClickResumeButton()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tGame Resumed");
        }

        // resume game time
        Time.timeScale = 1f;
        pauseOverlay.minigameStage = PauseOverlay.MinigameStage.Paused;
        gameObject.SetActive(false);
    }

    public void OnClickExitButton()
    {
        Time.timeScale = 1f;
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
