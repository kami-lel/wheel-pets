using UnityEngine;
using UnityEngine.InputSystem;

public class FoodObject : MonoBehaviour
{
    [SerializeField] float FoodAmount = 10f;
    [SerializeField] int ScoreAmount = 1;
    private bool WasMouseDown = false;

    // Update is called once per frame
    void Update() //to-do: figure out if touchscreen counts as mouse position.
    {
        if (WasMouseDown) // 
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10f;
            transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }
    private void OnMouseDown()
    {
        WasMouseDown = true;
    }
    private void OnMouseUp()
    {
        WasMouseDown = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject thingyHit = collision.gameObject;
        if(thingyHit.transform.name == "Pet")
        {
            thingyHit.transform.GetComponent<HungerHandler>().SatiateHunger(FoodAmount);
            Destroy(this.gameObject);
        }
    }
}
