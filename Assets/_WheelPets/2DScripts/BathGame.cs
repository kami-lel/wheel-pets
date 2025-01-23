using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class BathGame : MonoBehaviour
{
    [SerializeField] public GameObject targetObject; // The object to check for collisions with
    [SerializeField] public TextMeshProUGUI mistakeText; // Text to display mistakes
    [SerializeField] public TextMeshProUGUI messageText; // Text to display messages

    // Order booleans
    private bool isBrushUsed = false;
    private bool isClippersUsed = false;
    private bool isSoapUsed = false;
    private bool isWaterUsed = false;
    private bool isTowelUsed = false;
    private bool isScissorsUsed = false;

    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target object not assigned in the Inspector!");
        }

        if (messageText == null || mistakeText == null)
        {
            Debug.LogError("TextMeshProUGUI components not assigned in the Inspector!");
        }
    }

    public void NotifyItemDragged(string itemTag)
    {
        GameObject draggedItem = GameObject.FindWithTag(itemTag);

        if (mistakeText.text != "XXX" && !isScissorsUsed) // Check if mistakes are less than 3 and towel is not used
        {
            if (itemTag == "brush")
            {
                if (!isBrushUsed)
                {
                    isBrushUsed = true;
                    DisplayMessage("The dog is brushed and looking tidy.");
                    RemoveItem(draggedItem);
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                }
            }
            else if (itemTag == "clippers")
            {
                if (isBrushUsed && !isClippersUsed)
                {
                    isClippersUsed = true;
                    DisplayMessage("The dog has been clipped.");
                    RemoveItem(draggedItem);
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                }
            }
            else if (itemTag == "soap")
            {
                if (isBrushUsed && isClippersUsed && !isSoapUsed)
                {
                    isSoapUsed = true;
                    DisplayMessage("The dog is lathered.");
                    RemoveItem(draggedItem);
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                }
            }
            else if (itemTag == "water")
            {
                if (isBrushUsed && isClippersUsed && isSoapUsed && !isWaterUsed)
                {
                    isWaterUsed = true;
                    DisplayMessage("The dog is rinsed.");
                    RemoveItem(draggedItem);
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                }
            }
            else if (itemTag == "towel")
            {
                if (isWaterUsed && !isTowelUsed)
                {
                    isTowelUsed = true;
                    DisplayMessage("The dog is dried off.");
                    RemoveItem(draggedItem);
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                }
            }
            else if (itemTag == "scissors")
            {
                if(isTowelUsed && !isScissorsUsed)
                {
                    isScissorsUsed = true;
                    DisplayMessage("All done");
                    RemoveItem(draggedItem);
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                }
            }
        }
    }

    private void RemoveItem(GameObject item)
    {
        if (item != null)
        {
            item.SetActive(false); // Make the item invisible and non-interactable
        }
    }

    private void DisplayMistake(string mistake)
    {
        if (mistakeText != null)
        {
            mistakeText.text += mistake; // Append mistake
        }
    }

    private void DisplayMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
        }
    }
}
