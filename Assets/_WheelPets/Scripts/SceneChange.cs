using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// FIXME josh test "back" button (e.g. in settings) actual go back
public class SceneChange : MonoBehaviour
{
    public static void LoadCloset()
    {
        SceneManager.LoadScene("StoreScene");
        // BUG disable closet for this release
        // SceneManager.LoadScene("ClosetScene");
    }

    public static void LoadDrivingGame()
    {
        SceneManager.LoadScene("DrivingGameScene");
    }

    public static void LoadLeaderboard()
    {
        SceneManager.LoadScene("LeaderboardScene");
    }

    public static void LoadOptions()
    {
        SceneManager.LoadScene("OptionsScene");
    }

    public static void LoadPlayMenu()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public static void LoadSelector()
    {
        SceneManager.LoadScene("_SelectorScene");
    }

    public static void LoadStore()
    {
        SceneManager.LoadScene("StoreScene");
    }

    public static void LoadTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public static void LoadBath()
    {
        SceneManager.LoadScene("BathScene");
    }

    public static void LoadFeed()
    {
        SceneManager.LoadScene("FeedScene");
    }

    public static void LoadFetch()
    {
        SceneManager.LoadScene("FetchScene");
    }

    public static void LoadHideAndSeek()
    {
        SceneManager.LoadScene("HideNSeekScene");
    }

    public static void LoadTOW()
    {
        SceneManager.LoadScene("TugOWarScene");
    }

    public static void LoadWalk()
    {
        SceneManager.LoadScene("WalkScene");
    }

    public static void LoadFeedInstructions()
    {
        SceneManager.LoadScene("FeedingInstructions");
    }

    /// <summary>
    /// Manages the logic for exiting the adoption scene intelligently based on pet adoption status.
    /// </summary>
    /// <remarks>
    /// If a pet has never been adopted, which often occurs after a factor reset,
    /// exiting the adoption scene will navigate the user to the Driving Simulator.
    /// If a pet has already been adopted, exiting the adoption scene will navigate the user to the Options scene.
    /// </remarks>
    public static void LeaveAdoptionScene()
    {
        if (Data.GetPlayerData().hasAdoptPet)
        {
            LoadOptions();
        }
        else
        {
            LoadDrivingGame();
        }
    }
}

// fixme rm this class is not in use anymore
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

    // Load GameScene
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

    public void LoadClosetScene()
    {
        StartCoroutine(LoadSceneWithDelay("ClosetScene"));
    }

    public void LoadMinigameSelectorSecene()
    {
        StartCoroutine(LoadSceneWithDelay("_SelectorScene"));
    }

    public void LoadDogCareScene()
    {
        StartCoroutine(LoadSceneWithDelay("DogWalkScene"));
    }

    public void LoadDogBathScene()
    {
        StartCoroutine(LoadSceneWithDelay("DogBathScene"));
    }

    public void LoadTugOfWarScene()
    {
        StartCoroutine(LoadSceneWithDelay("Tug-o-WarScene"));
    }

    public void LoadFetchScene()
    {
        StartCoroutine(LoadSceneWithDelay("FetchScene"));
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
