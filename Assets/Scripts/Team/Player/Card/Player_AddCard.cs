using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UltimateClean;

public class Player_AddCard : MonoBehaviour
{
    [SerializeField] public GameObject prefab_playercard;
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

        Pos tpos = p.GetPos();
        switch (tpos)
        {
            case Pos.Attacker:
                player_image.color = new Color32(19, 87, 14, 255);
                break;
            case Pos.Midfielder:
                player_image.color = new Color32(87, 78, 14, 255);
                break;
            case Pos.Defender:
                player_image.color = new Color32(87, 19, 14, 255);
                break;
            case Pos.Goalie:
                player_image.color = new Color32(158, 103, 103, 255);
                break;
            case Pos.Wild:
                player_image.color = new Color32(47, 14, 87, 255);
                break;
            default:
                player_image.color = new Color32(0, 0, 0, 255);
                break;
        }

        switch (chem)
        {
            case Chem.None:
                image_leftChem.color = new Color32(0, 0, 0, 0);
                image_rightChem.color = new Color32(0, 0, 0, 0);
                break;
            case Chem.Left:
                image_leftChem.color = new Color32(0, 0, 0, 200);
                image_rightChem.color = new Color32(0, 0, 0, 0);
                break;
            case Chem.Right:
                image_leftChem.color = new Color32(0, 0, 0, 0);
                image_rightChem.color = new Color32(0, 0, 0, 200);
                break;
            case Chem.Both:
                image_leftChem.color = new Color32(0, 0, 0, 200);
                image_rightChem.color = new Color32(0, 0, 0, 200);
                break;
            default:
                image_leftChem.color = new Color32(0, 0, 0, 0);
                image_rightChem.color = new Color32(0, 0, 0, 0);
                break;
        }

        UpdateText();
    }

    public void AddPlayerToTeam()
    {
        GameObject newPlayerObject = Instantiate(prefab_playercard, transform.position, Quaternion.identity);
        newPlayerObject.name = p.n;
        //newPlayerObject.transform.SetParent(this.targetTeam.lineup.slot_newPlayer.transform);
        newPlayerObject.transform.position = this.targetTeam.lineup.slot_newPlayer.transform.position;
        newPlayerObject.GetComponent<Player_Card>().dragger.CheckDropSlots();

        newPlayerObject.GetComponent<Player_Card>().InitPlayer(p, targetTeam);
        //Debug.Log("Loaded player: " + n + " " + position);

        //Disable this card?

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
