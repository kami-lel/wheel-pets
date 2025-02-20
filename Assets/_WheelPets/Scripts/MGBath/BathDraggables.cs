using UnityEngine;
using UnityEngine.EventSystems;

public class BathDraggables : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;
    private bool isDragging = false;

    void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;

        BathGame bathGame = FindObjectOfType<BathGame>();
        if (
            bathGame != null
            && RectTransformUtility.RectangleContainsScreenPoint(
                bathGame.targetObject.GetComponent<RectTransform>(),
                rectTransform.position,
                canvas.worldCamera
            )
        )
        {
            bathGame.NotifyItemDragged(gameObject.tag);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging && canvas != null)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                eventData.position,
                canvas.worldCamera,
                out Vector2 position
            );

            rectTransform.localPosition = position;
        }
    }
}
