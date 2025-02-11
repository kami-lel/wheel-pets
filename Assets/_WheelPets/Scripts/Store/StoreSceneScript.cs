using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreSceneScript : MonoBehaviour
{
    public void ClosetButtonOnClick()
    {
        SceneManager.LoadScene("ClosetScene");
    }

    public void SettingsButtonOnClick()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void MinigameButtonOnClick()
    {
        SceneManager.LoadScene("_SelectorScene");
    }

    public void LeaveButtonOnClick()
    {
        SceneManager.LoadScene("_SelectorScene");
    }
}
