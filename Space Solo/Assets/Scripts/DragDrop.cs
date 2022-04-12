using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IEndDragHandler, IBeginDragHandler, IDragHandler
{

    //https://www.youtube.com/watch?v=BGr-7GZJNXg

    [SerializeField] private Canvas canvas;

    private CanvasGroup canvasgroup;
    private RectTransform rectTransform;
    private void Awake()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasgroup = GetComponent<CanvasGroup>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Start Drag");
        canvasgroup.alpha = .6f;
        canvasgroup.blocksRaycasts = false; // 1 after it is already dragging so that others Underneath can detect mouse.
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("ON Drag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; //Makes movement Possible, delta contains movement data of Mouse from Previous Frame. / canvas korjaa liikkumis virheet.
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        canvasgroup.alpha = 1;
        canvasgroup.blocksRaycasts = true; // 2 after Dropping making it possible to pick up again
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Down");
    }
}
