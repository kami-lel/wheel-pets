using UnityEngine;

public class ItemSelection : MonoBehaviour
{
    private RectTransform thisRect;
    [SerializeField] private string Description; // if items end up having descriptions, use this, otherwise it can be culled.
    private string Name;
    [SerializeField] private int cost;
    [SerializeField] private GameObject SelectScreen;
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
        Vector2 localMousePosition = thisRect.InverseTransformPoint(Input.mousePosition);
        if (thisRect.rect.Contains(localMousePosition) && Input.GetMouseButtonDown(0))
        {
            SelectScreen.SetActive(true);
            SelectScreen.transform.GetComponent<BuyScreenMenu>().Enable(Name, cost);
        }
    }
}
