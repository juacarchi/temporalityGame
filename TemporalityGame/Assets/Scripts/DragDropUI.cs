using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragDropUI : MonoBehaviour, IDragHandler, IDropHandler
{
    Rigidbody2D rb2D;
    BoxCollider2D bx;
    public float xMin, xMax;
    public float yMin, yMax;
    DayButton new_dayButton;
    Cabina new_cabina;
    public float zValue = 1;
    float step;
    float speed = 600;
    RectTransform rectGO;
    bool isDraging = true;
    bool isReturning;
    Vector2 anchoredPositionInitial;

    private void Awake()
    {
        xMin = -6.9f;
        xMax = 6.9f;
        yMin = -4.6f;
        yMax = 4.6f;

        new_dayButton = GetComponent<DayButton>();
        rb2D = GetComponent<Rigidbody2D>();
        bx = GetComponent<BoxCollider2D>();
        rectGO = GetComponent<RectTransform>();
        anchoredPositionInitial = rectGO.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Button buttonPressed = this.GetComponent<Button>();
        buttonPressed.enabled = false;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = zValue;
        Vector3 point = Camera.main.ScreenToWorldPoint(mousePosition);
        
        point.x = Mathf.Clamp(point.x, xMin, xMax);
        point.y = Mathf.Clamp(point.y, yMin, yMax);
        transform.position = point;
        rb2D.simulated = false;
        isDraging = true;
        isReturning = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        rb2D.simulated = true;
        Debug.Log("Suelta");
        Button buttonPressed = this.GetComponent<Button>();
        buttonPressed.enabled = true;
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
        if (other.CompareTag(new_dayButton.tagButton))
        {
            new_cabina = other.GetComponent<Cabina>();
            new_cabina.textCabina.enabled = true;
            Debug.Log("Ese es su sitio");
            GameManager.instance.SumaAcierto();
            FXManager.instance.InstantitateFX(0, this.transform);
            Destroy(this.gameObject);
            AudioCorrectManager.instance.PlaySFX(new_cabina.audioCabina);
        }
        else
        {
            isReturning = true;
            SoundManager.instance.PlaySFX(SoundManager.instance.failSound);
        }
    }
}
