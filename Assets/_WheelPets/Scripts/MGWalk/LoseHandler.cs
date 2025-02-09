using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseHandler : MonoBehaviour
{
    public AudioSource LoseSound; // Reference to the AudioSource (assign in Inspector)
    public string loseTag = "Rock"; // Tag for objects that trigger a loss
    public AudioSource MusicSource; // cue to end music
    public void BackButtonOnClick()
    {
        SceneManager.LoadScene("_SelectorScene");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(loseTag))
        {
            Debug.Log("Player collided with a lose-triggering object. Disabling controls...");

            // Disable DogJump scripts
            var dogJump = GetComponent<DogJump>();
            if (dogJump != null)
            {
                dogJump.DisableControls();
            }

            // Disable RockMovement scripts
            var rockMovements = FindObjectsOfType<RockMovement>(true);
            foreach (var rockMovement in rockMovements)
            {
                rockMovement.enabled = false;
            }

            // Play lose sound and load scene
            if (LoseSound != null)
            {
                StartCoroutine(PlaySoundAndLoadScene());
            }
            else
            {
                Debug.LogError("LoseSound AudioSource is not assigned.");
                MusicSource.Stop();
                SceneManager.LoadScene("PetGameScene"); // Fallback if sound is not assigned
            }
        }
    }

    private IEnumerator PlaySoundAndLoadScene()
    {
        DontDestroyOnLoad(LoseSound.gameObject); // Keep sound playing across scene loads
        LoseSound.Play();
        Debug.Log("Playing LoseSound...");
        yield return new WaitForSeconds(LoseSound.clip.length); // Wait for the sound to finish
        Debug.Log("Sound finished. Loading Menu scene...");
        SceneManager.LoadScene("PetGameScene");
    }
}
