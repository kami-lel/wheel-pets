using UnityEngine;
using UnityEngine.EventSystems;

public class BathDraggables : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private bool isDragging = false;
    private Vector3 originalPosition;
    private Vector3 offset;

    void Start()
    {
        originalPosition = transform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 0));
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;

        BathGame bathGame = FindFirstObjectByType<BathGame>();
        if (bathGame != null)
        {
            Collider2D targetCollider = bathGame.targetObject.GetComponent<Collider2D>();
            Collider2D itemCollider = GetComponent<Collider2D>();

            if (targetCollider != null && itemCollider != null)
            {
                bool isColliding = itemCollider.IsTouching(targetCollider);

                Debug.Log("Collision check: " + isColliding);

                if (isColliding)
                {
                    bathGame.NotifyItemDragged(gameObject.tag);
                }
                else
                {
                    // Return the item to its original position if not colliding
                    transform.position = originalPosition;
                }
            }
            else
            {
                Debug.LogError("Collider2D component not found on target object or item!");
            }
        }
        else
        {
            Debug.LogError("BathGame script not found!");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 0)) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, originalPosition.z);
        }
    }
}
