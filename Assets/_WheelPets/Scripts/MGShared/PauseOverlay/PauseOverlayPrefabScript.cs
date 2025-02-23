using UnityEngine;

// fixme translate this doc as google doc
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
    public void PauseButtonOnClick()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tPause Button Clicked");
        }

        pauseContainer.gameObject.SetActive(true);
    }

    /// <summary>
    /// This function should be called when the minigame ends
    /// with a victory.
    /// It serves as an interface function to work with the PauseOverlay.
    /// </summary>
    public void MinigameWin()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tWin Triggered");
        }

        // TODO Implementation for handling win conditions goes here
    }

    /// <summary>
    /// This function should be called when the minigame ends
    /// in a loss.
    /// It serves as an interface function to work with the PauseOverlay.
    /// </summary>
    public void MinigameLost()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tLose Triggered");
        }

        // TODO Implementation for handling loss conditions goes here
    }

    // whether to require a click on the "start" button to begin the game
    [SerializeField]
    private bool requireStartButtonToStart = true;

    [SerializeField]
    private GameObject preStartContainer;

    [SerializeField]
    private PauseContainer pauseContainer;

    [SerializeField]
    private WinContainer winContainer;

    [SerializeField]
    private LoseContainer loseContainer;

    public enum MinigameStage
    {
        PreStart, // before mingame start, with prestart screen
        Running,
        Paused,
        Won,
        Lost,
    }

    public MinigameStage minigameStage;

    private void Start()
    {
        // turn off pause/win/lose containers
        pauseContainer.gameObject.SetActive(false);
        winContainer.gameObject.SetActive(false);
        loseContainer.gameObject.SetActive(false);

        if (requireStartButtonToStart)
        {
            // showing a pre-start screen before game start
            minigameStage = MinigameStage.PreStart;
            preStartContainer.SetActive(true);
        }
        else
        {
            // maek game run directly
            minigameStage = MinigameStage.Running;
            preStartContainer.SetActive(false);
        }
    }

    void OnApplicationQuit()
    {
        Time.timeScale = 1f;
    }
}
