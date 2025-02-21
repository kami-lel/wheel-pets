using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// bug replace static pet with PetPrebab
// todo add start button
// todo add more instruction for how to play the game
// todo add high score function

// a single loose
public class LoseHandler : MonoBehaviour
{
    public AudioSource LoseSound; // Reference to the AudioSource (assign in Inspector)
    public string loseTag = "Rock"; // Tag for objects that trigger a loss

    public void BackButtonOnClick()
    {
        SceneChange.LoadSelector();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(loseTag))
        {
            if (Debug.isDebugBuild)
            {
                Debug.Log(
                    "LoseHandler\tPlayer collided with a lose-triggering object. Disabling controls..."
                );
            }

            // Disable DogJump scripts
            var dogJump = GetComponent<DogJump>();
            if (dogJump != null)
            {
                dogJump.DisableControls();
            }

            // Disable RockMovement scripts
            var rockMovements = FindObjectsByType<RockMovement>(
                FindObjectsSortMode.None
            );
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
                SceneChange.LoadPlayMenu(); // Fallback if sound is not assigned
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
        SceneChange.LoadSelector();
    }
}
