using UnityEngine;
using UnityEngine.SceneManagement;

// bug replace static pet with PetPrebab
// todo add start button
// todo add more instruction for how to play the game
// todo add high score function
public class FetchSceneScript : MonoBehaviour
{
    public void BackButtonOnClick()
    {
        SceneChange.LoadSelector();
    }

    public void PlayAgainButtonOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}