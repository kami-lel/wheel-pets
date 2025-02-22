using TMPro;
using UnityEngine;

public class BuyScreenMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    TMP_Text name_text;

    private int costu;
    private string itemSelected;

    private PlayerData playerData;

    private void Start()
    {
        playerData = Data.GetPlayerData();
    }

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
        if (playerData.drivingPoint >= costu)
        {
            // if enoguh points subtract cost
            playerData.drivingPoint -= costu;

            // Optional confirm message
            Debug.Log(
                "Purchased "
                    + itemSelected
                    + " for "
                    + costu
                    + " driving point"
            );
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
