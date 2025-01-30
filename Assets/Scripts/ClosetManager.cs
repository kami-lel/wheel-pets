using UnityEngine;

public class ClosetManager : MonoBehaviour
{
   public void AddItem(string itemName, int quantity, Sprite itemSprite)
   {
    Debug.Log("itemName = " + itemName + "quantity =" + quantity + "itemSprite =" + itemSprite);
   } 
}
