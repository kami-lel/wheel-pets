using UnityEngine;
using UnityEngine.SceneManagement;

public class MGSelectorSceneScript : MonoBehaviour
{
    public void BackButtonOnClick()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void DogWalkButtonOnClick()
    {
        SceneManager.LoadScene("WalkScene");
    }

    public void DogBathButtonOnClick()
    {
        SceneManager.LoadScene("BathScene");
    }

    public void TugOWarButtonButtonOnClick()
    {
        SceneManager.LoadScene("TugOWarScene");
    }

    public void FetchButtonOnClick()
    {
        SceneManager.LoadScene("FetchScene");
    }

    public void HideNSeekButtonOnClick()
    {
        SceneManager.LoadScene("HideNSeekScene");
    }
}
