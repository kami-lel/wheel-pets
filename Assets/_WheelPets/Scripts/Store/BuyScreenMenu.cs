using UnityEngine;
using TMPro;

public class BuyScreenMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] TMP_Text name_text;
    private int costu;
    public void Enable(string name, int cost)
    {
        itemSelected = name;
        name_text.text = "Purchase " + name + "?";
        costu = cost;
        this.gameObject.SetActive(true);
    }

    // Call this method when the cancel button is pressed
    public void CancelPurchase()
    {
        Disable();
    }

    public void ConfirmPurchase()
    {
        // Check if the user has enough driving points
        if (PlayerData.Data.drivingPoint >= costu)
        {
            // if enoguh points subtract cost
            PlayerData.Data.drivingPoint -= costu;

            // Optional confirm message
            Debug.Log("Purchased " + itemSelected + " for " + costu + " driving point");

            // Save updated player data to file
            PlayerData.SaveToFile();
        }
        else
        {
            // Inform that user doesn't have enough points
            Debug.Log("Not enough driving point");
        }
        
        // Disable the purchase screen regardless of purchase
        Disable();
    }
    
    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
    
    
}
