
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] public Button select;
    [SerializeField] public TextMeshProUGUI text_stats;

    //Selected panel
    [SerializeField] public GameObject panel_selected;
    //[SerializeField] public Button button_close;

    [SerializeField] public TMP_Dropdown dropdown_positionAct;
    [SerializeField] public TMP_Dropdown dropdown_slot;

    //[SerializeField] public Button button_att;
    //[SerializeField] public Button button_mid;
    //[SerializeField] public Button button_def;
    //[SerializeField] public Button button_bench;

    //[SerializeField] public Button button_incSlot;
    //[SerializeField] public Button button_decSlot;

    //[SerializeField] public TextMeshProUGUI text_slot;

    public Team team;

    public int power;
    public string myName;
    public string position;

    public bool selected;
    public string positionAct;
    public int perferredSlot;

    void Awake()
    {
        Init();

        select.onClick.AddListener(ShowPanel);

        dropdown_positionAct.onValueChanged.AddListener(PositionActChanged);
        dropdown_slot.onValueChanged.AddListener(SlotChanged);
    }

    void Start()
    {
        UpdateText();

        HidePanel();
    }

    public void Init()
    {
        power = 0;
        myName = "Default";
        selected = false;
        position = "Att";

        positionAct = "Bench";
        perferredSlot = 0;
    }

    public void Init(Player fromP)
    {
        Init();

        power = fromP.power;
        myName = fromP.myName;
        selected = false;
        position = fromP.position;

        positionAct = fromP.positionAct;
    }

    public void AssignToTeam(Team assignedTeam)
    {
        this.team = assignedTeam;
    }

    public void UpdateText()
    {
        text_stats.text = $"Name: {myName}\nStars: {power}\nPosition: {position}\nLineup: {positionAct}";
        //text_slot.text = $"( {perferredSlot} )";
    }

    //private
    private void PositionActChanged(int arg0)
    {
        positionAct = dropdown_positionAct.options[dropdown_positionAct.value].text;
        UpdateText();
        HidePanel();
    }

    private void SlotChanged(int arg0)
    {
        perferredSlot = dropdown_positionAct.value;
        UpdateText();
        HidePanel();
    }    

    private void HidePanel()
    {
        panel_selected.gameObject.SetActive(false);
    }

    private void ShowPanel()
    {
        panel_selected.gameObject.SetActive(true);
    }
}
