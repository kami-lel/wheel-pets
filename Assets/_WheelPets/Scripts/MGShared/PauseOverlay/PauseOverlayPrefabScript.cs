using UnityEngine;
using UnityEngine.SceneManagement;

// FIXME translate this doc as google doc
/* Implement Pause Function for any Scene
 *
 * How to use:
 * 1. Drag `PauseOverlay` **Prefab** into Hierachy, as a child of main Canvas
 * 2. create a Pause Button, links its On Click() with PauseOverlay.PauseButtonOnClick()
 */


// TODO check if applied to all scenes correctly
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
        pauseContainer.gameObject.SetActive(true);
    }

    // hack backward compatiblity
    public void PauseButtonOnClick()
    {
        MinigamePause();
    }

    /// <summary>
    /// This function should be called when the minigame ends
    /// with a victory.
    /// It serves as an interface function to work with the PauseOverlay.
    /// </summary>
    public void MinigameWin()
    {
        winContainer.gameObject.SetActive(true);
    }

    /// <summary>
    /// This function should be called when the minigame ends
    /// in a loss.
    /// It serves as an interface function to work with the PauseOverlay.
    /// </summary>
    public void MinigameLost()
    {
        loseContainer.gameObject.SetActive(true);
    }

    // whether to require a click on the "start" button to begin the game
    [SerializeField]
    private bool requireStartButtonToStart = true;

    [SerializeField]
    private PreStartContainer preStartContainer;

    [SerializeField]
    private PauseContainer pauseContainer;

    [SerializeField]
    private WinContainer winContainer;

    [SerializeField]
    private LoseContainer loseContainer;

    public enum Status
    {
        Running = 0,
        PreStart,
        Paused,
        Won,
        Lost,
    }

    public Status status = Status.Running;

    private void Start()
    {
        // turn off pause/win/lose containers
        pauseContainer.gameObject.SetActive(false);
        winContainer.gameObject.SetActive(false);
        loseContainer.gameObject.SetActive(false);

        // showing a pre-start screen before game start
        preStartContainer.gameObject.SetActive(requireStartButtonToStart);
    }

    // used by containers
    public void StopMinigameTimeAndAudio()
    {
        Time.timeScale = 0f;
        // BUG currently it doesn't stop sound & bgm
    }

    // used by containers
    public void ContinueMinigameTimeAndAudio()
    {
        Time.timeScale = 1f;
        // BUG currently it doesn't stop sound & bgm
    }

    // used by containers
    public void ReloadMinigameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnApplicationQuit()
    {
        Time.timeScale = 1f;
    }
}
