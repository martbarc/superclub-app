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

    public GameObject cardObj;
    public PlayerCard card;

    public Pos pos;
 
    public void Init(Pos position)
    {
        Player ptemp = new Player();
        ptemp.pos = (ushort)position;
        //var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
        _renderer.color = ptemp.GetPlayerColor();//isOffset ? _offsetColor : _baseColor;
        this.pos = position;

        if (position == Pos.Bench)
        {
            _renderer.sortingOrder = 27;
        }
    }
 
    // void OnMouseEnter() 
    // {
    //     if (cardObj == null) _highlight.SetActive(true);
    // }
 
    // void OnMouseExit()
    // {
    //     if (cardObj == null) _highlight.SetActive(false);
    // }

    public bool SlotCard(GameObject newCardObj, bool checkActive = true)
    {
        if (checkActive)
        {
            if (this.gameObject.activeSelf == false)
            {
                return false;
            }
        }

        newCardObj.transform.position = this.transform.position;

        if(SlotCardIfClose(newCardObj, checkActive))
        {
            return true;
        }

        return false;
    }

    public bool SlotCardIfClose(GameObject cardObj, bool checkActive = true)
    {
        if (IsPositionClose(cardObj.transform.position))
        {
            PlayerCard c = cardObj.GetComponent<PlayerCard>();
            if (c != null)
            {
                this.cardObj = cardObj;
                this.cardObj.transform.position = this.transform.position;
                this.cardObj.transform.SetParent(this.transform);

                this.card = c;
                this.card.p.posAct = (ushort)pos;
                this.card.dragger.connectedSlot = this;
                this.card.team.Recalc(); //trigger recalc
            }
            Debug.Log($"PlayerCard added to {this.name}");
            return true;
        }
        return false;
    }

    public bool IsPositionClose(Vector3 p, bool checkActive = true)
    {
        if (checkActive)
        {
            if (this.gameObject.activeSelf == false)
            {
                return false;
            }
        }

        if (Mathf.Abs(this.transform.position.x - p.x) <= xTol && Mathf.Abs(this.transform.position.y - p.y) <= yTol)
        {
            return true;
        }
        return false;
    }

    public GameObject ClearSlot()
    {
        GameObject gObj = cardObj;
        card.gameObject.transform.SetParent(card.team.lineup.transform);
        cardObj = null;
        card = null;
        return gObj;
    }
}