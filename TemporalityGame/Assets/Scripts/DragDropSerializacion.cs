using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DragDropSerializacion : MonoBehaviour, IDragHandler, IDropHandler
{
    Image imageElement;
    RectTransform rectGO;
    Rigidbody2D rb2D;
    BoxCollider2D bx;
    float step;
    float speed = 600;

    public float zValue = 1;
    bool isDraging = true;
    Vector2 anchoredPositionInitial;

    private void Awake()
    {
        imageElement = GetComponent<Image>();
        rectGO = GetComponent<RectTransform>();
        anchoredPositionInitial = rectGO.anchoredPosition;

        rb2D = GetComponent<Rigidbody2D>();
        bx = GetComponent<BoxCollider2D>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = zValue;
        Vector3 point = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = point;
        rb2D.simulated = false;
        rb2D.isKinematic = false;
        isDraging = true;
    }

    public void OnDrop(PointerEventData eventData)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        
        rb2D.simulated = true;
        rb2D.isKinematic = false;
        Debug.Log("Suelta");
        isDraging = false;

    }

    private void Update()
    {
        if (!isDraging)
        {
            rectGO.anchoredPosition = Vector2.MoveTowards(rectGO.anchoredPosition, anchoredPositionInitial, step);
        }
        step = speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.CompareTag(this.tag))
        {
            if (other.CompareTag("antes"))
            {
                Image imageOther = other.GetComponent<Image>();
                imageOther.color = Color.white;
                imageOther.sprite = imageElement.sprite;
                Debug.Log("Antes");
                FXManager.instance.InstantitateFX(0, this.transform);
                GameManager.instance.SumaAcierto();
                Destroy(this.gameObject);
            }
            else if (other.CompareTag("ahora"))
            {
                Image imageOther = other.GetComponent<Image>();
                imageOther.color = Color.white;
                imageOther.sprite = imageElement.sprite;
                Debug.Log("Ahora");
                FXManager.instance.InstantitateFX(0, this.transform);
                GameManager.instance.SumaAcierto();
                Destroy(this.gameObject);
            }
            else if (other.CompareTag("despues"))
            {
                Image imageOther = other.GetComponent<Image>();
                imageOther.color = Color.white;
                imageOther.sprite = imageElement.sprite;
                Debug.Log("Después");
                FXManager.instance.InstantitateFX(0, this.transform);
                GameManager.instance.SumaAcierto();
                Destroy(this.gameObject);
            }
        }
    }
}
