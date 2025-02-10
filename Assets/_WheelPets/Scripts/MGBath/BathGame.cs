using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BathGame : SceneSwapping
{
    [SerializeField]
    public GameObject targetObject; // The object to check for collisions with

    [SerializeField]
    public TextMeshProUGUI mistakeText; // Text to display mistakes

    [SerializeField]
    public TextMeshProUGUI messageText; // Text to display messages

    // Order booleans
    private bool isBrushUsed = false;
    private bool isClippersUsed = false;
    private bool isSoapUsed = false;
    private bool isWaterUsed = false;
    private bool isTowelUsed = false;
    private bool isScissorsUsed = false;

    // sfx
    [SerializeField] private AudioSource Soapy;
    [SerializeField] private AudioSource watery;
    [SerializeField] private AudioSource towely;
    [SerializeField] private AudioSource cutty;
    [SerializeField] private AudioSource brushy;
    [SerializeField] private AudioSource clippy;
    [SerializeField] private AudioSource incorrect_sound;

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

    public void BackButtonOnClick()
    {
        SceneManager.LoadScene("_SelectorScene");
    }

    void Update()
    {
        // Check if mistakes reached "XXX" and switch to PetGame Scene
        if (mistakeText.text == "XXX")
        {
            SceneManager.LoadScene("_SelectorScene");
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
                    brushy.Play();
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                    incorrect_sound.Play();
                }
            }
            else if (itemTag == "clippers")
            {
                if (isBrushUsed && !isClippersUsed)
                {
                    isClippersUsed = true;
                    DisplayMessage("The dog has been clipped.");
                    RemoveItem(draggedItem);
                    clippy.Play();
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                    incorrect_sound.Play();
                }
            }
            else if (itemTag == "soap")
            {
                if (isBrushUsed && isClippersUsed && !isSoapUsed)
                {
                    isSoapUsed = true;
                    DisplayMessage("The dog is lathered.");
                    RemoveItem(draggedItem);
                    Soapy.Play();
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                    incorrect_sound.Play();
                }
            }
            else if (itemTag == "water")
            {
                if (isBrushUsed && isClippersUsed && isSoapUsed && !isWaterUsed)
                {
                    isWaterUsed = true;
                    DisplayMessage("The dog is rinsed.");
                    RemoveItem(draggedItem);
                    watery.Play();
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                    incorrect_sound.Play();
                }
            }
            else if (itemTag == "towel")
            {
                if (isWaterUsed && !isTowelUsed)
                {
                    isTowelUsed = true;
                    DisplayMessage("The dog is dried off.");
                    RemoveItem(draggedItem);
                    towely.Play();
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                    incorrect_sound.Play();
                }
            }
            else if (itemTag == "scissors")
            {
                if (isTowelUsed && !isScissorsUsed)
                {
                    isScissorsUsed = true;
                    DisplayMessage("All done");
                    RemoveItem(draggedItem);
                    cutty.Play();
                }
                else
                {
                    DisplayMistake("X");
                    DisplayMessage("You can't use that yet.");
                    incorrect_sound.Play();
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
