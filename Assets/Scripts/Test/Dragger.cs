// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.EventSystems;

// public class Dragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
// {
//     public Camera mainCamera;
//     public float zAxis = 0;
//     public Vector3 clickOffset = Vector3.zero;

//     public List<DropSlot> slots;
//     public DropSlot curSlot;

//     //private bool isMouseDrag;

//     void Awake()
//     {
//         mainCamera = Camera.main;
//         if (mainCamera.GetComponent<Physics2DRaycaster>() == null)
//             mainCamera.gameObject.AddComponent<Physics2DRaycaster>();
//     }

//     public void Init(List<DropSlot> s)
//     {
//         slots = s;
//     }

//     // void Update()
//     // {
//     //     if (isMouseDrag)
//     //     {
//     //         Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
//     //         transform.Translate(mousePosition);
//     //     }
//     // }

//     public void OnBeginDrag(PointerEventData eventData)
//     {
//         //Debug.Log("OnBeginDrag");
//         zAxis=transform.position.z;
//         clickOffset = transform.position - mainCamera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, zAxis)) + new Vector3(0, 3, 0);
//         transform.position = new Vector3(transform.position.x, transform.position.y, zAxis);

//         if (curSlot != null)
//             curSlot.ClearSlot();
//             curSlot = null;
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//         //Use Offset To Prevent Sprite from Jumping to where the finger is
//         Vector3 tempVec = mainCamera.ScreenToWorldPoint(eventData.position) + clickOffset;
//         tempVec.z = zAxis; //Make sure that the z zxis never change

//         transform.position = tempVec;
//     }

//     public void OnEndDrag(PointerEventData eventData)
//     {
//         //Debug.Log("OnEndDrag");
//         transform.position = new Vector3(transform.position.x, transform.position.y, 0);

//         CheckDropSlots();
//     }

//     public bool CheckDropSlots()
//     {
//         foreach (DropSlot s in slots)
//         {
//             if (s.SetIfPositionClose(this.gameObject))
//             {
//                 curSlot = s;
//                 return true;
//             }
//         }
//         return false;
//     }

//     //Add Event System to the Camera
//     void addEventSystem()
//     {
//         GameObject eventSystem = new GameObject("EventSystem");
//         eventSystem.AddComponent<EventSystem>();
//         eventSystem.AddComponent<StandaloneInputModule>();
//     }

//     // public void OnMouseDown()
//     // {
//     //     isMouseDrag = true;
//     // }

//     // public void OnMouseUp()
//     // {
//     //     isMouseDrag = false;
//     // }
// }
