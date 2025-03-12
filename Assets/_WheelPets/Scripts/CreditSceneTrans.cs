using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSceneTrans : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void GoToTitle()
    {
        SceneChange.LoadTitle();
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("CreditsScene");
    }
}
