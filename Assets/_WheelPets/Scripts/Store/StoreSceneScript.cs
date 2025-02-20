using UnityEngine;
using UnityEngine.SceneManagement;

// bug replace static pet with PetPrebab
public class StoreSceneScript : MonoBehaviour
{
    public void ClosetButtonOnClick()
    {
        SceneChange.LoadCloset();
    }

    public void SettingsButtonOnClick()
    {
        SceneChange.LoadOptions();
    }

    public void MinigameButtonOnClick()
    {
        SceneChange.LoadSelector();
    }

    public void LeaveButtonOnClick()
    {
        SceneChange.LoadPlayMenu();
    }
}
