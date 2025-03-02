using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneTranser : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void MenuScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
