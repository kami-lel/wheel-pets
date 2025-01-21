using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class StoreTabGroup : MonoBehaviour
{
    public List<StoreTabButton> tabButtons;
    public Color tabIdleColor = Color.white;
    public Color tabHoverColor = Color.green;
    public Color tabActiveColor = Color.green;
    public StoreTabButton selectedTab;
    public List<GameObject> objectsToSwap;
    public AudioSource buttonClickSound; // Add this line

    public void AddToList(StoreTabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<StoreTabButton>();
        }
        tabButtons.Add(button);
    }

    public void OnTabEnter(StoreTabButton button)
    {
        ResetTabs();
        if (selectedTab == null || button != selectedTab)
        {
            button.background.color = tabHoverColor;
        }
    }

    public void OnTabExit(StoreTabButton button)
    {
        ResetTabs();
    }

    public void OnTabSelected(StoreTabButton button)
    {
        selectedTab = button;
        ResetTabs();
        button.background.color = tabActiveColor;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++)
        {
            objectsToSwap[i].SetActive(i == index);
        }
        PlayButtonClickSound(); // Add this line
    }

    private void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
        }
    }

    public void ResetTabs()
    {
        foreach (StoreTabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab) { continue; }
            button.background.color = tabIdleColor;
        }
    }
}
