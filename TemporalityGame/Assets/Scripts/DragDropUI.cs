using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropUI : MonoBehaviour, IDragHandler, IDropHandler
{
    DayButton new_dayButton;
    Cabina new_cabina;
    public float zValue = 1;

    private void Awake()
    {
        new_dayButton = GetComponent<DayButton>();
    }

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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(new_dayButton.tagButton))
        {
            new_cabina = other.GetComponent<Cabina>();
            new_cabina.textCabina.enabled = false;
            Debug.Log("Ese es su sitio");
        }
    }
}
