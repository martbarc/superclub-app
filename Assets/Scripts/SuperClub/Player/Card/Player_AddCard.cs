using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UltimateClean;

public class Player_AddCard : MonoBehaviour
{
    [SerializeField] public Team targetTeam;
    [SerializeField] public TextMeshProUGUI text_name;
    //[SerializeField] public TextMeshProUGUI text_power;
    [SerializeField] public TextMeshProUGUI text_stats;
    [SerializeField] public TextMeshProUGUI text_tradevalue;
    [SerializeField] public TextMeshProUGUI text_scoutvalue;

    [SerializeField] public Counter counter_position;
    [SerializeField] public Counter counter_power;
    [SerializeField] public Counter counter_chem;

    [SerializeField] public Image player_image;
    [SerializeField] public Image image_leftChem;
    [SerializeField] public Image image_rightChem;

    [SerializeField] public CleanButton button_add;

    public Player p;

    void Awake()
    {
        button_add.onClick.AddListener(AddPlayerToTeam);

        counter_position.inc = 1f;
        counter_position.counter_min = 0f;
        counter_position.counter_max = 6f;
        counter_power.inc = 1f;
        counter_power.counter_min = 0f;
        counter_chem.prepend = "Chem: ";
        counter_chem.inc = 1f;
        counter_chem.counter_min = 0f;
        counter_chem.counter_max = 3f;
    }

    void Start()
    {
        counter_position.AddListenerToCounterChange(UpdateText);
        counter_power.AddListenerToCounterChange(UpdateText);
        counter_chem.AddListenerToCounterChange(UpdateText);

        p = new Player();
        p.InitCustom();

        UpdateText();
    }

    public void InitPlayer(Team team, ushort id, string name, Pos pos, float power, Chem chem, ushort tval, ushort sval)
    {
        p = new Player(id, name, pos, power, chem, tval, sval);

        //player_image.color = p.GetPlayerColor();
        //(image_leftChem.color, image_rightChem.color) = p.GetPlayerChemColor();

        counter_power.UpdateCounter(p.pow);

        UpdateText();
    }

    public void AddPlayerToTeam()
    {
        if (targetTeam.lineup.AddPlayerToLineup(p))
        {
            //Debug.Log("Player added to lineup");
        }
        else
        {
            Debug.Log("ERROR: Player failed to add to lineup!");
        }

        //Close Shop
    }

    public void UpdateText()
    {
        text_name.text = p.n;
        //text_power.text = $"{p.pow}";

        // if (selected)
        //     text_stats.text = p.GetString() + $"\n[SELECTED]";
        // else
        //     text_stats.text = p.GetString();

        text_tradevalue.text =  $"{p.tval}M";
        text_scoutvalue.text =  $"{p.sval}M";
        //text_slot.text = $"( {perferredSlot} )";

        if (p.custom) //if custom check what counter option is selected
        {
            p.pow = counter_power.counter;
            p.SetPosVal((ushort) counter_position.counter);
            p.SetChemVal((ushort) counter_chem.counter);
        }

        counter_power.UpdateText();
        player_image.color = p.GetPlayerColor();
        (image_leftChem.color, image_rightChem.color) = p.GetPlayerChemColor();
    }
}
