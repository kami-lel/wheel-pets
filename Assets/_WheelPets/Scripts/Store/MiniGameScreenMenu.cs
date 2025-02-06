using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MiniGameScreenMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] TMP_Text desc_text;
    [SerializeField] private GameObject Minigames;
    private string Game;
    public void Enable(string name, string descript)
    {
        desc_text.text = "How to Play:\n" + descript;
        Game = name;
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
        Minigames.SetActive(true);
    }

    public void Transition()
    {
        SceneManager.LoadScene(Game);
    }
}
