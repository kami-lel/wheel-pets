/* * * * * * * * * * * * 
* 
*
*
* * * * * * * * * * * * */
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoseHandler : MonoBehaviour{
    public AudioSource LoseSound; // Reference to the AudioSource (assign in Inspector)

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player")){
            Debug.Log("Player collided with wall. Stopping score, disabling input, playing sound, and loading Menu scene...");

            // Disable input in relevant scripts
            var inputController = FindObjectOfType<InputController>(true);
            if (inputController != null) inputController.enabled = false;
            
            var arrowKeyControllers = FindObjectsOfType<ArrowKeyController>(true);
            foreach (var controller in arrowKeyControllers) controller.enabled = false;

            // Play death sound and load Menu scene
            if (LoseSound != null) StartCoroutine(PlaySoundAndLoadScene());
            else{
                Debug.LogError("LoseSound AudioSource is not assigned.");
                SceneManager.LoadScene("PetGameScene"); // Fallback if sound is not assigned
            }   
        }
    }

    private IEnumerator PlaySoundAndLoadScene(){
        DontDestroyOnLoad(LoseSound.gameObject); // Keep sound playing across scene loads
        LoseSound.Play();
        Debug.Log("Playing LoseSound...");
        yield return new WaitForSeconds(LoseSound.clip.length); // Wait for the sound to finish
        Debug.Log("Sound finished. Loading Menu scene...");
        SceneManager.LoadScene("PetGameScene");
    }
    
    public void Start()
    {
    }
}
