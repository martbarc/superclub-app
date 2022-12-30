using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;

    private float xTol = 4f;
    private float yTol = 5f;

    public GameObject curGameObject;
 
    public void Init(bool isOffset) {
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }
 
    void OnMouseEnter() {
        _highlight.SetActive(true);
    }
 
    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

    public bool SetIfPositionClose(GameObject gObj)
    {
        Vector3 p = gObj.transform.position;
        if (IsPositionClose(p))
        {
            if (gObj.GetComponent<PlayerCard>() != null)
            {
                curGameObject = gObj;
                gObj.transform.position = this.transform.position;

                gObj.GetComponent<PlayerCard>().team.Recalc();
            }

            return true;
        }
        return false;
    }

    public bool IsPositionClose(Vector3 p)
    {
        if (Mathf.Abs(this.transform.position.x - p.x) <= xTol && Mathf.Abs(this.transform.position.y - p.y) <= yTol)
        {
            return true;
        }
        return false;
    }

    public GameObject ClearSlot()
    {
        GameObject gObj = curGameObject;
        curGameObject = null;
        return gObj;
    }
}