using UnityEngine;

public class PauseContainer : MonoBehaviour
// BUG currently it doesn't stop sound & bgm
{
    public void ResumeButtonOnClick()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;

        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tGame Resumed");
        }
    }

    public void ExitButtonOnClick()
    {
        Time.timeScale = 1f;
        SceneChange.LoadSelector();
    }

    public void VolumeSliderOnValueChanged(System.Single value)
    {
        // BUG volume slider not working

        if (Debug.isDebugBuild)
        {
            Debug.Log($"PauseOverlay\tmain volume changed to {value}");
        }
    }
}
