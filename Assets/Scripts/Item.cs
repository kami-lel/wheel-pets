using UnityEngine;
using System.Collections;
using UnityEngine;

// this is assuming we have itmes that can be picked up. A placeholder
// will be made for debugging purposes till we settle on how the closet
// is properly interacted with.

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;

    private ClosetManager closetManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        closetManager = GameObject.Find("ClosetCanvas").GetComponent<ClosetManager>();   
    }

private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Player")
    {
        closetManager.AddItem(itemName, quantity, sprite);
        Destroy(gameObject);
    }
}
}
