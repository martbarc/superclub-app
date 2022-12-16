//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DragDrop : MonoBehaviour
//{
//    public bool canMove;
//    public bool dragging;

//    private Collider2D c;
//    void Start()
//    {
//        c = GetComponent<Collider2D>();
//        canMove = false;
//        dragging = false;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//        if (Input.GetMouseButtonDown(0) || Input.touchCount > 1)
//        {
//            if (c == Physics2D.OverlapPoint(mousePos))
//            {
//                canMove = true;
//            }
//            else
//            {
//                canMove = false;
//            }
//            if (canMove)
//            {
//                dragging = true;
//            }


//        }

//        if (dragging)
//        {
//            this.transform.position = mousePos;
//        }

//        if (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended))
//        {
//            canMove = false;
//            dragging = false;
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;


    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

}