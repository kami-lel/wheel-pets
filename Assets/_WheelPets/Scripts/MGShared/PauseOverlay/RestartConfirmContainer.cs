using UnityEngine;

public class RestartConfirmContainer : MonoBehaviour
{
    public void OnClickConfirmButton()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tRetart Game from RestartConfirm Screen");
        }
        // TODO
        gameObject.SetActive(false);
    }

    public void OnClickResumeButton()
    {
        if (Debug.isDebugBuild)
        {
            Debug.Log("PauseOverlay\tResume Game from RestartConfirm Screen");
        }
        // TODO
        gameObject.SetActive(false);
    }
}
