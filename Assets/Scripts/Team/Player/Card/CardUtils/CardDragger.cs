using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] public PlayerCard card;

    private Camera mainCamera;
    private float zAxis = 0;
    public Vector3 clickOffset = Vector3.zero;

    public List<CardSlot> slots;
    public CardSlot connectedSlot;

    //private bool isMouseDrag;

    void Awake()
    {
        mainCamera = Camera.main;
        if (mainCamera.GetComponent<Physics2DRaycaster>() == null)
            mainCamera.gameObject.AddComponent<Physics2DRaycaster>();
    }

    public void Init(List<CardSlot> s)
    {
        slots = s;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        zAxis=transform.position.z;
        clickOffset = transform.position - mainCamera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, zAxis)) + new Vector3(0, 3, 0);
        this.transform.position = new Vector3(transform.position.x, transform.position.y, zAxis);
        card.SelectCard(true);

        if (connectedSlot != null)
        {
            connectedSlot.ClearSlot();
            connectedSlot = null;

            if (card.p.posAct == (ushort)Pos.Bench)
            {
                //Switch to lineup view
                card.team.lineup.SetBenchView(false);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Use Offset To Prevent Sprite from Jumping to where the finger is
        Vector3 tempVec = mainCamera.ScreenToWorldPoint(eventData.position) + clickOffset;
        tempVec.z = zAxis; //Make sure that the z zxis never change

        transform.position = tempVec;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        card.SelectCard(false);

        if (CheckDropSlots() == false)
        {
            Debug.Log("CardSlot not found, moving to bench");
            if (card.team.lineup.MovePlayerCardToBench(this.gameObject))
            {
                
            }
        }
    }

    public bool CheckDropSlots()
    {
        foreach (CardSlot s in slots)
        {
            if (s.SlotCardIfClose(this.gameObject))
            {
                return true;
            }
        }
        return false;
    }

    //Add Event System to the Camera
    void addEventSystem()
    {
        GameObject eventSystem = new GameObject("EventSystem");
        eventSystem.AddComponent<EventSystem>();
        eventSystem.AddComponent<StandaloneInputModule>();
    }

    // public void OnMouseDown()
    // {
    //     isMouseDrag = true;
    // }

    // public void OnMouseUp()
    // {
    //     isMouseDrag = false;
    // }
}