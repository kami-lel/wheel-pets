using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Implement Pause Function for any Scene
 *
 * How to use:
 * 1. Drag `PauseOverlay` **Prefab** into Hierachy, as a child of main Canvas
 * 2. create a Pause Button, links its On Click() with PauseOverlay.PauseButtonOnClick()
 */


// todo applied to all scenes
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
        Debug.Log(playerData);
        container.SetActive(true);

        // stop game stime
        Time.timeScale = 0f;

        // update slider visually with current settings
        volumeSlider.value = playerData.mainVolume;

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
        Time.timeScale = 1f;
        SceneChange.LoadDrivingGame();
    }

    public void VolumeSliderOnValueChanged(System.Single value)
    {
        playerData.mainVolume = value;
        // todo inform audio player to update volume

        if (Debug.isDebugBuild)
        {
            Debug.Log($"PauseOverlay\tmain volume changed to {value}");
        }
    }

    private PlayerData playerData;

    void Start()
    {
        playerData = Data.GetPlayerData();
        if (playerData != null)
        {
            Debug.Log("Player data loaded");
            Debug.Log(playerData);
        }
        else
        {
            Debug.Log("Player data not loaded");
        }

        // pause screen is disabled by default
        container.SetActive(false);
    }

    void OnApplicationQuit()
    {
        Time.timeScale = 1f;
        Data.SavePlayerDataToFile();
    }
}
