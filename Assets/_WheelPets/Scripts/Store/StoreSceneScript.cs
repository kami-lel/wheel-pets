using UnityEngine;
using UnityEngine.SceneManagement;

// BUG christina replace static pet with PetPrebab
// TODO christina make store functional w/ placeholder pictures
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
