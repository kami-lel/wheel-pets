using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// todo add more instruction for how to play the game
public class BathSceneScript : MonoBehaviour
{
    public GameObject playAgainButton;
    public AudioSource buttonClickSound;

    void Start()
    {
        // Add button listener
        if (playAgainButton != null)
        {
            playAgainButton
                .GetComponent<UnityEngine.UI.Button>()
                .onClick.AddListener(OnPlayAgainButtonClick);
        }
    }

    public void ShowPlayAgainButton()
    {
        StartCoroutine(ShowPlayAgainButtonRoutine());
    }

    IEnumerator ShowPlayAgainButtonRoutine()
    {
        yield return new WaitForSeconds(2.0f);
        if (playAgainButton != null)
        {
            playAgainButton.SetActive(true);
        }
    }

    void OnPlayAgainButtonClick()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
        }
        StartCoroutine(RestartGameAfterSound());
    }

    IEnumerator RestartGameAfterSound()
    {
        if (buttonClickSound != null)
        {
            yield return new WaitForSeconds(buttonClickSound.clip.length);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackButtonOnClick()
    {
        SceneManager.LoadScene("_SelectorScene");
    }
}
