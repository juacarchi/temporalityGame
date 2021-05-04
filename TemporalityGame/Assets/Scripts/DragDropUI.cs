using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragDropUI : MonoBehaviour, IDragHandler, IDropHandler
{
    Rigidbody2D rb2D;
    BoxCollider2D bx;

    DayButton new_dayButton;
    Cabina new_cabina;
    public float zValue = 1;

    private void Awake()
    {
        new_dayButton = GetComponent<DayButton>();
        rb2D = GetComponent<Rigidbody2D>();
        bx=GetComponent<BoxCollider2D>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Button buttonPressed = this.GetComponent<Button>();
        buttonPressed.enabled = false;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = zValue;
        Vector3 point = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = point;
        rb2D.simulated = false ;
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        rb2D.simulated = true;
        Debug.Log("Suelta");
        Button buttonPressed = this.GetComponent<Button>();
        buttonPressed.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(new_dayButton.tagButton))
        {
            new_cabina = other.GetComponent<Cabina>();
            new_cabina.textCabina.enabled = true;
            Debug.Log("Ese es su sitio");
            GameManager.instance.SumaAcierto();
            Destroy(this.gameObject);

        }
    }
}
