using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDropTrain : MonoBehaviour, IDragHandler, IDropHandler
{
    Rigidbody2D rb2D;
    BoxCollider2D bx;

    public float zValue = 1;

    private void Awake()
    {
        
        rb2D = GetComponent<Rigidbody2D>();
        bx = GetComponent<BoxCollider2D>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Button buttonPressed = this.GetComponent<Button>();
        buttonPressed.enabled = false;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = zValue;
        Vector3 point = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = point;
        rb2D.simulated = false;
        rb2D.isKinematic = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        rb2D.simulated = true;
        Debug.Log("Suelta");
        Button buttonPressed = this.GetComponent<Button>();
        buttonPressed.enabled = true;
    }
}
