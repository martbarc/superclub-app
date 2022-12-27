using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour
{
    public Vector3 v;
    public float xTol = 3f;
    public float yTol = 3f;

    public GameObject curGameObject;

    void Awake()
    {
        v = this.transform.position;
    }

    public bool SetIfPositionClose(GameObject gObj)
    {
        Vector3 p = gObj.transform.position;
        if (IsPositionClose(p))
        {
            if (gObj.GetComponent<Player_Card>() != null)
            {
                curGameObject = gObj;
                gObj.transform.position = this.transform.position;

                gObj.GetComponent<Player_Card>().team.Recalc();
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
