using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropController : MonoBehaviour
{
    public static DragAndDropController instance;
    Touch touch;
    public float speed;
    public float minXValue = -4.0f;
    public float maxXValue = 4.0f;
    float speedMobile = 0.01f;
    float yCoord;
    Vector3 yOffset;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
    private void Update()
    {

        #region Movement WebGL
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(Vector3.right * moveX, Space.World);
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minXValue, maxXValue);
        transform.position = clampedPosition;

        #endregion
        #region Movement Mobile
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speedMobile, transform.position.y, transform.position.z);
            }
        }

        #endregion

    }
    #region Movement DragWithMouse

    private void OnMouseDown()
    {
        //FIJAR EN LA POSICIÓN DE Y AL PULSAR
        yCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).y;
        yOffset = gameObject.transform.position - GetMouseWorldPos();
    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.y = yCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + yOffset;
    }


    #endregion
}
