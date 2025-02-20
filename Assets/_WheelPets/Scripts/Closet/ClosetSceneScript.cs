using UnityEngine;
using UnityEngine.SceneManagement;

// todo make closet scene functional w/ placholder assets images
public class ClosetSceneScript : MonoBehaviour
{
    public void BackButtonOnClick()
    {
        SceneChange.LoadPlayMenu();
    }
}
