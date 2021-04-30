using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropUI : MonoBehaviour, IDragHandler, IDropHandler
{
    public float zValue = 1;
    public void OnDrag(PointerEventData eventData)
    {
      
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = zValue;
        Vector3 point = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = point;
    }

    public void OnDrop(PointerEventData eventData)
    {
        
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        
    }
}
