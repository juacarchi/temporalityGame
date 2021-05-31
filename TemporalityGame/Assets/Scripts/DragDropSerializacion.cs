using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragDropSerializacion : MonoBehaviour, IDragHandler, IDropHandler
{
    Image imageElement;
    RectTransform rectGO;
    Rigidbody2D rb2D;
    BoxCollider2D bx;
    float step;
    float speed = 600;
    float xMin, xMax, yMin, yMax; //Mathf.Clamp
    public float zValue = 1;
    bool isDraging = true;
    bool isReturning;
    Vector2 anchoredPositionInitial;
    bool wasTaken;

    private void Awake()
    {
        imageElement = GetComponent<Image>();
        

        rb2D = GetComponent<Rigidbody2D>();
        bx = GetComponent<BoxCollider2D>();
        xMin = -6.9f;
        xMax = 6.9f;
        yMin = -4.6f;
        yMax = 4.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!wasTaken)
        {
            rectGO = GetComponent<RectTransform>();
            anchoredPositionInitial = rectGO.anchoredPosition;
            wasTaken = true;
        }
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = zValue;
        Vector3 point = Camera.main.ScreenToWorldPoint(mousePosition);
        point.x = Mathf.Clamp(point.x, xMin, xMax);
        point.y = Mathf.Clamp(point.y, yMin, yMax);
        transform.position = point;
        rb2D.simulated = false;
        rb2D.isKinematic = false;
        isDraging = true;
        isReturning = false;
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
        if (isReturning)
        {
            rb2D.simulated = false;
            rb2D.isKinematic = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag(this.tag))
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
        else
        {
            isReturning = true;
            SoundManager.instance.PlaySFX(SoundManager.instance.failSound);
        }
    }
}
