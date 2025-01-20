using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwapping : MonoBehaviour
{
    public AudioSource buttonClickSound;

    private void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
        }
    }

    public void LoadDrivingGameScene()
    {
        PlayButtonClickSound();
        SceneManager.LoadScene("DrivingGameScene");
    }

    public void LoadPetGameScene()
    {
        PlayButtonClickSound();
        SceneManager.LoadScene("PetGameScene");
    }

    public void LoadTitleScene()
    {
        PlayButtonClickSound();
        SceneManager.LoadScene("TitleScene");
    }

    public void LoadLeaderboardScene()
    {
        PlayButtonClickSound();
        SceneManager.LoadScene("LeaderboardScene");
    }

    public void LoadOptionsScene()
    {
        PlayButtonClickSound();
        SceneManager.LoadScene("OptionsScene");
    }

    public void LoadDogCareScene()
    {
        PlayButtonClickSound();
        SceneManager.LoadScene("DogWalkScene");
    }

    public void ExitGame()
    {
        PlayButtonClickSound();
        Application.Quit();
    }
}
