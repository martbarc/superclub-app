using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSelectPanel : MonoBehaviour
{
    //[SerializeField] public TMP_Dropdown dropdown_positionAct;

    [SerializeField] public Button button_attack;
    [SerializeField] public Button button_midfield;
    [SerializeField] public Button button_defense;
    [SerializeField] public Button button_goalie;

    [SerializeField] public Button button_moveLeft;
    [SerializeField] public Button button_moveRight;

    [SerializeField] public Team t;

    public PlayerObj p;

    void Awake()
    {
        //dropdown_positionAct.onValueChanged.AddListener(PositionActChanged);

        button_attack.onClick.AddListener(MoveToAtt);
        button_midfield.onClick.AddListener(MoveToMid);
        button_defense.onClick.AddListener(MoveToDef);
        button_goalie.onClick.AddListener(MoveToGoalie);

        button_moveLeft.onClick.AddListener(MoveLeft);
        button_moveRight.onClick.AddListener(MoveRight);
    }

    // private void PositionActChanged(int arg0)
    // {
    //     p.PositionActChanged(dropdown_positionAct.options[dropdown_positionAct.value].text);
    // }

    public void MoveToAtt()
    {
        p.PositionActChanged(Pos.Attacker);
    }

    public void MoveToMid()
    {
        p.PositionActChanged(Pos.Midfielder);
    }

    public void MoveToDef()
    {
        p.PositionActChanged(Pos.Defender);
    }

    public void MoveToGoalie()
    {
        p.PositionActChanged(Pos.Goalie);
    }

    public void MoveLeft()
    {
        p.MoveLeft();
    }

    public void MoveRight()
    {
        p.MoveRight();
    }

    public void HidePanel()
    {
        p = null;
        this.gameObject.SetActive(false);
    }

    public void ShowPanel(PlayerObj pobj)
    {
        p = pobj;
        this.gameObject.SetActive(true);
    }
}
