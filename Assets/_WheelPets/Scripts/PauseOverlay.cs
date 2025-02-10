using UnityEngine;

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

    // UI interface functions
    public void PauseButtonOnClick()
    {
        // TODO
    }

    public void ResumeButtonOnClick()
    {
        // TODO
    }

    public void ExitButtonOnClick()
    {
        // TODO
    }

    public void VolumeSliderOnValueChanged(System.Single value)
    {
        // TODO
    }

    private PlayerData playerData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerData = PlayerData.Data; // FIXME

        // pause screen is disabled by default
        container.SetActive(false);
    }

    // Update is called once per frame
    void Update() { }
}
