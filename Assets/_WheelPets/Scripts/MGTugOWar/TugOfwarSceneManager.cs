using UnityEngine;
using UnityEngine.SceneManagement;

public class TugOfWarSceneManager : MonoBehaviour
{
    public void OnBackButtonClick()
    {
        // Load the selector scene
        SceneChange.LoadSelector();
    }
}
