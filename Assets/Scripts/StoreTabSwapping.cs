using UnityEngine;

public class StoreTabSwapping : MonoBehaviour
{
    public GameObject storeCosmeticItems;
    public GameObject storeMinigames;
    public AudioSource buttonClickSound;

    public void OnMinigameButtonClick()
    {
        Debug.Log("Minigame button clicked");
        PlayButtonClickSound();
        ShowMinigamesTab();
    }

    public void OnCosmeticButtonClick()
    {
        Debug.Log("Cosmetic button clicked");
        PlayButtonClickSound();
        ShowCosmeticItemsTab();
    }

    private void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            Debug.Log("Playing button click sound");
            buttonClickSound.Play();
        }
        else
        {
            Debug.LogWarning("Button click sound is not assigned");
        }
    }

    private void ShowMinigamesTab()
    {
        if (storeCosmeticItems != null)
        {
            Debug.Log("Hiding store cosmetic items");
            storeCosmeticItems.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Store cosmetic items GameObject is not assigned");
        }

        if (storeMinigames != null)
        {
            Debug.Log("Showing store minigames");
            storeMinigames.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Store minigames GameObject is not assigned");
        }
    }

    private void ShowCosmeticItemsTab()
    {
        if (storeCosmeticItems != null)
        {
            Debug.Log("Showing store cosmetic items");
            storeCosmeticItems.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Store cosmetic items GameObject is not assigned");
        }

        if (storeMinigames != null)
        {
            Debug.Log("Hiding store minigames");
            storeMinigames.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Store minigames GameObject is not assigned");
        }
    }
}
