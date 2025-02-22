using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Implement Pause Function for any Scene
 *
 * How to use:
 * 1. Drag `PauseOverlay` **Prefab** into Hierachy, as a child of main Canvas
 * 2. create a Pause Button, links its On Click() with PauseOverlay.PauseButtonOnClick()
 */


// TODO check if applied to all scenes correctly;w
// BUG currently it doesn't stop sound & bgm
public class PauseOverlay : MonoBehaviour
{
    /// <summary>
    /// This function should be called when one wants to pause the minigame
    /// and bring the pause screen.
    /// This function is often called by a Pause Button.
    /// It serves as an interface function to work with the PauseOverlay.
    /// </summary>
    public void MinigamePause()
    {
        // TODO implement the logic to pause the minigame and display the pause overlay
    }

    /// <summary>
    /// This function should be called when the minigame ends
    /// with a victory.
    /// It serves as an interface function to work with the PauseOverlay.
    /// </summary>
    public void MinigameWin()
    {
        // TODO Implementation for handling win conditions goes here
    }

    /// <summary>
    /// This function should be called when the minigame ends
    /// in a loss.
    /// It serves as an interface function to work with the PauseOverlay.
    /// </summary>
    public void MinigameLost()
    {
        // TODO Implementation for handling loss conditions goes here
    }

    // whether to require a click on the "start" button to begin the game
    [SerializeField]
    private bool requireStartButtonToStart = true;

    [SerializeField]
    private GameObject preStartContainer;

    [SerializeField]
    private GameObject pauseContainer;

    [SerializeField]
    private GameObject winContainer;

    [SerializeField]
    private GameObject loseContainer;

    [SerializeField]
    private Slider volumeSlider;

    // UI interface functions
    public void PauseButtonOnClick()
    {
        // display the overlay
        Debug.Log(playerData);
        pauseContainer.SetActive(true);

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
        pauseContainer.SetActive(false);
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
        playerData.mainVolume = value;
        // TODO inform audio player to update volume

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
        pauseContainer.SetActive(false);
    }

    void OnApplicationQuit()
    {
        Time.timeScale = 1f;
    }
}
