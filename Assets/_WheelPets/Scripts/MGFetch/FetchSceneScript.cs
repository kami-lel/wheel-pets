using UnityEngine;
using UnityEngine.SceneManagement;

// bug replace static pet with PetPrebab
public class FetchSceneScript : MonoBehaviour
{
    public void BackButtonOnClick()
    {
        SceneChange.LoadSelector();
    }
}
