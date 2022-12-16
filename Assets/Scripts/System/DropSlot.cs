using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSlot : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");

        if (eventData.pointerDrag != null)
        {
            RectTransform t = eventData.pointerDrag.GetComponent<RectTransform>();
            t.anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }

    }
}
