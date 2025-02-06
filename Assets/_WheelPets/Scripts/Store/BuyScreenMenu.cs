using UnityEngine;
using TMPro;

public class BuyScreenMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] TMP_Text name_text;
    private int costu;
    public void Enable(string name, int cost)
    {
        name_text.text = "Purchase " + name + "?";
        costu = cost;
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
