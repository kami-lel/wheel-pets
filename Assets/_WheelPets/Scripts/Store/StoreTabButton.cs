using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class StoreTabButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public StoreTabGroup tabGroup;

    public Image background;

    public void OnPointerClick(PointerEventData eventData)
    {
        tabGroup.OnTabSelected(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tabGroup.OnTabExit(this);
    }

    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.AddToList(this);
        if (tabGroup.tabIdleColor == Color.white) // Only set if not already set
        {
            tabGroup.tabIdleColor = background.color;
        }
        background.color = tabGroup.tabIdleColor;
    }
}
