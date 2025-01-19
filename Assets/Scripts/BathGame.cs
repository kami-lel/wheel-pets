using UnityEngine;
using UnityEngine.EventSystems;

public class BathGame : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private GameObject targetObject; // The object to check for collisions with
    private RectTransform buttonRectTransform; // The RectTransform of the button
    private Canvas canvas; // The parent Canvas
    private bool isDragging = false;

    void Start()
    {
        buttonRectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        if (targetObject == null)
        {
            Debug.LogError("Target object not assigned in the Inspector!");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Start dragging when the pointer is pressed on the button
        isDragging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Stop dragging when the pointer is released
        isDragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // If dragging, update the position of the button
        if (isDragging)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                eventData.position,
                canvas.worldCamera,
                out position
            );
            buttonRectTransform.localPosition = position;
        }
    }

    void Update()
    {
        if (targetObject == null) return;

        // Check for collision with the target object
        RectTransform targetRect = targetObject.GetComponent<RectTransform>();
        if (targetRect != null && RectTransformUtility.RectangleContainsScreenPoint(targetRect, buttonRectTransform.position, canvas.worldCamera))
        {
            Debug.Log("Button collided with the target object!");
        }
    }
}
