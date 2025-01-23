using UnityEngine;

public class TugOfWarFlag : MonoBehaviour
{
    public TugOfWarManager tugOfWarManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("GoalLine"))
        {
            Debug.Log("Flag touched the goal line");
            tugOfWarManager.TriggerWinState();
        }
    }
}
