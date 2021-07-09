using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DrugAndDrop : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] GameObject parentPointerUp;
    [SerializeField] GameObject parentPointerDown;

    private bool isDraging;
    private Vector2 mousePosition;

    public void OnPointerDown(PointerEventData eventData) 
    {
        isDraging = true;
        transform.parent = parentPointerDown.transform;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDraging = false;
        transform.parent = parentPointerUp.transform;
    }

    private void Update()
    {
        if (isDraging)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }
}
