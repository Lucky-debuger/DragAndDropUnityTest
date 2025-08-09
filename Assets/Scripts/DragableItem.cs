using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfterDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Start dragging!");
        parentAfterDrag = transform.parent; // Store the current parent
        transform.SetParent(transform.root); // Set the parent to the root to avoid hierarchy issues during
        transform.SetAsLastSibling(); // Bring the item to the front
        image.raycastTarget = false; // Disable raycast target to allow interaction with the item while dragging

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging!");
        transform.position = eventData.position; // Update position to follow the mouse
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End dragging!");
        transform.SetParent(parentAfterDrag); // Restore the original parent
        image.raycastTarget = true; // Re-enable raycast target
    }
}
