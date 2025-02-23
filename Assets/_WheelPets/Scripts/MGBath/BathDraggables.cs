using UnityEngine;
using UnityEngine.EventSystems;

public class BathDraggables : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private bool isDragging = false;
    private Vector3 originalPosition;
    private Vector3 offset;

    void Start()
    {
        Debug.Log($"{gameObject.name} - Start: Original position set to {originalPosition}");
    }

    public void SetOriginalPosition(Vector3 position)
    {
        originalPosition = position;
        Debug.Log($"{gameObject.name} - SetOriginalPosition: Original position set to {originalPosition}");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 0));
        Debug.Log($"{gameObject.name} - OnPointerDown: Dragging started with offset {offset}");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        Debug.Log($"{gameObject.name} - OnPointerUp: Dragging stopped");

        BathGame bathGame = FindFirstObjectByType<BathGame>();
        if (bathGame != null)
        {
            Collider2D targetCollider = bathGame.targetCollider;
            Collider2D itemCollider = GetComponent<Collider2D>();

            if (targetCollider != null && itemCollider != null)
            {
                Vector2 itemPosition = itemCollider.bounds.center;
                bool isColliding = targetCollider.OverlapPoint(itemPosition);
                Debug.Log($"{gameObject.name} - OnPointerUp: Collision check with target object: {isColliding}");

                if (isColliding)
                {
                    bathGame.NotifyItemDragged(gameObject.tag);
                }
                else
                {
                    // Return the item to its original position if not colliding
                    transform.position = originalPosition;
                    Debug.Log($"{gameObject.name} - OnPointerUp: Returned to original position {originalPosition}");
                }
            }
            else
            {
                Debug.LogError($"{gameObject.name} - OnPointerUp: Collider2D component not found on target object or item!");
            }
        }
        else
        {
            Debug.LogError($"{gameObject.name} - OnPointerUp: BathGame script not found!");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 0)) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, originalPosition.z);
            Debug.Log($"{gameObject.name} - OnDrag: New position set to {transform.position}");
        }
    }
}
