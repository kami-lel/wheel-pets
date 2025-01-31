using UnityEngine;

public class ClosetManager : MonoBehaviour
{
   public ItemSlot[] itemSlot;

   public void AddItem(string itemName, int quantity, Sprite itemSprite)
   {
      for (int i = 0; i < itemSlot.Length; i++)
      {
         if(itemSlot[i].isFull == false)
         {
            itemSlot[i].AddItem(itemName, quantity, itemSprite);
            return;
         }
      }
      Debug.Log("itemName = " + itemName + "quantity =" + quantity + "itemSprite =" + itemSprite);
   } 

   public void DeselectAllSlots()
   {
      for (int i = 0; i < itemSlot.Length; i++)
      {
         itemSlot[i].selectedShader.SetActive(false);
         itemSlot[i].thisItemSelected = false;
      }
   }
}
