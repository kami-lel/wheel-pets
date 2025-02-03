using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneScript : MonoBehaviour
{
    public void ClickPlayButton()
    {
        Debug.LogWarning("play"); // TODO
    }

    public void ClickOptionsButton()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public void ClickLeaderboardButton()
    {
        SceneManager.LoadScene("LeaderboardScene");
    }

    public void ClickExitButton()
    {
        Application.Quit();
    }
}
