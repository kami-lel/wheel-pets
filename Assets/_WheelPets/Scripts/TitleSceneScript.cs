using UnityEngine;
using UnityEngine.SceneManagement;

// TODO fix all warnings

public class TitleSceneScript : MonoBehaviour
{
    public void ClickPlayButton()
    {
        SceneManager.LoadScene("PlayScene");
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
