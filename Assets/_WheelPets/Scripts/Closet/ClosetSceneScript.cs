using UnityEngine;
using UnityEngine.SceneManagement;

// TODO make closet scene functional w/ placholder assets images
public class ClosetSceneScript : MonoBehaviour
{
    public void BackButtonOnClick()
    {
        SceneChange.LoadPlayMenu();
    }
}
