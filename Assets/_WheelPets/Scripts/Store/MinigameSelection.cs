using UnityEngine;

// TODO minigame unlock mechanism
public class MinigameSelection : MonoBehaviour
{
    private RectTransform thisRect;

    [SerializeField]
    private string Description;
    private string Name;

    [SerializeField]
    private GameObject GameSelectScreen;

    [SerializeField]
    private GameObject Minigames;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thisRect = this.GetComponent<RectTransform>();
        Name = this.name;
    }

    // testing code found at https://discussions.unity.com/t/detect-when-mouseposition-in-a-recttransform/679903/6
    // Update is called once per frame
    void Update()
    {
        Vector2 localMousePosition = thisRect.InverseTransformPoint(
            Input.mousePosition
        );
        if (
            thisRect.rect.Contains(localMousePosition)
            && Input.GetMouseButtonDown(0)
        )
        {
            GameSelectScreen.SetActive(true);
            Minigames.SetActive(false);
            GameSelectScreen
                .transform.GetComponent<MiniGameScreenMenu>()
                .Enable(Name, Description);
        }
    }
}
