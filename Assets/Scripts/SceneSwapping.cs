using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

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

    private IEnumerator LoadSceneWithDelay(string sceneName)
    {
        PlayButtonClickSound();
        if (buttonClickSound != null)
        {
            yield return new WaitWhile(() => buttonClickSound.isPlaying);
        }
        SceneManager.LoadScene(sceneName);
    }

    public void LoadDrivingGameScene()
    {
        StartCoroutine(LoadSceneWithDelay("DrivingGameScene"));
    }

    public void LoadPetGameScene()
    {
        StartCoroutine(LoadSceneWithDelay("PetGameScene"));
    }

    public void LoadTitleScene()
    {
        StartCoroutine(LoadSceneWithDelay("TitleScene"));
    }

    public void LoadLeaderboardScene()
    {
        StartCoroutine(LoadSceneWithDelay("LeaderboardScene"));
    }

    public void LoadOptionsScene()
    {
        StartCoroutine(LoadSceneWithDelay("OptionsScene"));
    }

    public void LoadDogCareScene()
    {
        StartCoroutine(LoadSceneWithDelay("DogWalkScene"));
    }

    public void ExitGame()
    {
        PlayButtonClickSound();
        StartCoroutine(ExitGameWithDelay());
    }

    private IEnumerator ExitGameWithDelay()
    {
        if (buttonClickSound != null)
        {
            yield return new WaitWhile(() => buttonClickSound.isPlaying);
        }
        Application.Quit();
    }
}
