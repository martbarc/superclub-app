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
    [SerializeField] public TextMeshProUGUI text_power;
    [SerializeField] public TextMeshProUGUI text_stats;
    [SerializeField] public TextMeshProUGUI text_tradevalue;
    [SerializeField] public TextMeshProUGUI text_scoutvalue;

    [SerializeField] public Image player_image;
    [SerializeField] public Image image_leftChem;
    [SerializeField] public Image image_rightChem;

    [SerializeField] public CleanButton button_add;
    

    public Player p;

    void Awake()
    {
        button_add.onClick.AddListener(AddPlayerToTeam);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InitPlayer(Team team, ushort id, string name, Pos pos, float power, Chem chem, ushort tval, ushort sval)
    {
        p = new Player(id, name, pos, power, chem, tval, sval);
        player_image.color = p.GetPlayerColor();
        (image_leftChem.color, image_rightChem.color) = p.GetPlayerChemColor();

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
        text_power.text = $"{p.pow}";

        // if (selected)
        //     text_stats.text = p.GetString() + $"\n[SELECTED]";
        // else
        //     text_stats.text = p.GetString();

        text_tradevalue.text =  $"{p.tval}M";
        text_scoutvalue.text =  $"{p.sval}M";
        //text_slot.text = $"( {perferredSlot} )";
    }
}
