using UnityEngine;
using UnityEngine.UI;

/* Implement Pause Function for any Scene
 *
 * How to use:
 * 1. Drag `PauseOverlay` **Prefab** into Hierachy, as a child of main Canvas
 * 2. create a Pause Button, links its On Click() with PauseOverlay.PauseButtonOnClick()
 */


public class PauseOverlay : MonoBehaviour
{
    [SerializeField]
    private GameObject container;

    [SerializeField]
    private Slider volumeSlider;

    // UI interface functions
    public void PauseButtonOnClick()
    {
        // display the overlay
        container.SetActive(true);

        // stop game stime
        Time.timeScale = 0f;

        // update slider visually with current settings

        // BUG
        // volumeSlider.value = playerData.mainVolume;

        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tGame Paused");
        }
    }

    public void ResumeButtonOnClick()
    {
        container.SetActive(false);
        Time.timeScale = 1f;

        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tGame Resumed");
        }
    }

    public void ExitButtonOnClick()
    {
        Application.Quit();
    }

    public void VolumeSliderOnValueChanged(System.Single value)
    {
        // BUG
        // playerData.mainVolume = value;
        // todo inform audio player to update volume

        if (Debug.isDebugBuild)
        {
            Debug.Log($"PauseOverlay\tmain volume changed to {value}");
        }
    }

    private PlayerData playerData;

    void Start()
    {
        playerData = PlayerData.Data; // FIXME

        // pause screen is disabled by default
        container.SetActive(false);
    }

    void OnApplicationQuit()
    {
        PlayerData.SaveToFile();
    }
}
