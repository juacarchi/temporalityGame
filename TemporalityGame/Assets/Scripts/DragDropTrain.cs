﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDropTrain : MonoBehaviour, IDragHandler, IDropHandler
{
    Image imageElement;
    RectTransform rectGO;
    Rigidbody2D rb2D;
    BoxCollider2D bx;
    float step;
    float speed = 600;

    public float zValue = 1;
    bool isDraging = true;
    bool isReturning;
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
        Button buttonPressed = this.GetComponent<Button>();
        buttonPressed.enabled = false;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = zValue;
        Vector3 point = Camera.main.ScreenToWorldPoint(mousePosition);
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
        if (this.tag==other.tag)
        {

            if (other.GetComponent<Vagon1>() != null)
            {
                Vagon1 vagon1 = other.GetComponent<Vagon1>();
                vagon1.SetTextActive();
            }
            if (other.GetComponent<Vagon2>() != null)
            {
                Vagon2 vagon2 = other.GetComponent<Vagon2>();
                vagon2.SetTextActive();
            }

            Debug.Log("Ese es su sitio");
            GameManager.instance.SumaAcierto();
            FXManager.instance.InstantitateFX(0, this.transform);
            Destroy(this.gameObject);
        }
        else
        {
            isReturning = true;
            SoundManager.instance.PlaySFX(SoundManager.instance.failSound);
        }
    }

}
