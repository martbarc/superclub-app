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

    [SerializeField] public Button button_bench;
    [SerializeField] public Button button_remove;

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

        button_bench.onClick.AddListener(MoveToBench);
        button_remove.onClick.AddListener(Remove);

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
        this.HidePanel();
    }

    public void MoveToMid()
    {
        p.PositionActChanged(Pos.Midfielder);
        this.HidePanel();
    }

    public void MoveToDef()
    {
        p.PositionActChanged(Pos.Defender);
        this.HidePanel();
    }

    public void MoveToGoalie()
    {
        p.PositionActChanged(Pos.Goalie);
        this.HidePanel();
    }

    public void MoveToBench()
    {
        p.MoveToBench();
        this.HidePanel();
    }

    public void Remove()
    {
        p.RemoveFromRoster();
        this.HidePanel();
    }

    public void MoveLeft()
    {
        p.MoveLeft();
        this.HidePanel();
    }

    public void MoveRight()
    {
        p.MoveRight();
        this.HidePanel();
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
