using UnityEngine;
using TMPro;

public class Player_Card : MonoBehaviour
{
    // UI
    [SerializeField] public SpriteRenderer image_back;
    [SerializeField] public SpriteRenderer image_leftChem;
    [SerializeField] public SpriteRenderer image_rightChem;
    // [SerializeField] public Button select;
    [SerializeField] public TextMeshPro text_name;
    [SerializeField] public TextMeshPro text_power;
    [SerializeField] public TextMeshPro text_stats;
    [SerializeField] public TextMeshPro text_value;

    // OBJ
    [SerializeField] public Team team;
    [SerializeField] public Dragger dragger;

    public Player p;
    //public Team team;

    public bool selected;
    public bool rostered;

    void Awake()
    {
        p = new Player();
        selected = false;
        rostered = false;

        //if (select != null) select.onClick.AddListener(onPlayerSelected);
    }

    void Start()
    {
        
        UpdateText();
    }

    public void InitPlayer(Player newP, Team targetTeam)
    {
        p = new Player(newP);
        team = targetTeam;
        dragger.Init(team.lineup.slots);

        Debug.Log($"Player_Card {p.n} Initialized");
    }

    public void UpdateText()
    {
        text_name.text = p.n;
        text_power.text = $"{p.pow}";

        // if (selected)
        //     text_stats.text = p.GetString() + $"\n[SELECTED]";
        // else
        //     text_stats.text = p.GetString();

        text_value.text = p.GetValueString();
        //text_slot.text = $"( {perferredSlot} )";
    }
}

/*

    public void InitPlayer(Team team, ushort id, string name, Pos pos, float power, Chem chem, ushort tval, ushort sval)
    {
        this.team = team;
        p = new Player(id, name, pos, power, chem, tval, sval);

        Pos tpos = p.GetPos();
        switch (tpos)
        {
            case Pos.Attacker:
                image_back.color = new Color32(19, 87, 14, 255);
                break;
            case Pos.Midfielder:
                image_back.color = new Color32(87, 78, 14, 255);
                break;
            case Pos.Defender:
                image_back.color = new Color32(87, 19, 14, 255);
                break;
            case Pos.Goalie:
                image_back.color = new Color32(158, 103, 103, 255);
                break;
            case Pos.Wild:
                image_back.color = new Color32(47, 14, 87, 255);
                break;
            default:
                image_back.color = new Color32(0, 0, 0, 255);
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

        if (p.id == 0)//(p.n == "Given")
        {
            MoveToBench();
        }
    }

    public void AssignToFormation(string formation, int slot)
    {
        if (p.formationSetting.ContainsKey(formation))
        {
            p.formationSetting[formation] = slot;
        }
        else
        {
            p.formationSetting.Add(formation, slot);
        }
        selected = false;
        UpdateText();
    }

    public void AssignToTeam(Team assignedTeam)
    {
        this.team = assignedTeam;
    }

    //private
    public void PositionActChanged(Pos position)
    {
        p.SetPosAct(position);
        Pos t = p.GetPosAct();

        switch(t)
        {
            case Pos.Attacker:
                this.gameObject.transform.SetParent(team.lineup.panel_attackers.transform);
                break;
            case Pos.Midfielder:
                this.gameObject.transform.SetParent(team.lineup.panel_middies.transform);
                break;
            case Pos.Defender:
                this.gameObject.transform.SetParent(team.lineup.panel_defense.transform);
                break;
            case Pos.Goalie:
                //Swap current goalie out
                if (team.lineup.panel_goalie.transform.childCount > 0)
                {
                    team.lineup.panel_goalie.transform.GetChild(0).SetParent(team.roster.transform);
                }

                this.gameObject.transform.SetParent(team.lineup.panel_goalie.transform);
                break;
            case Pos.Bench:
                MoveToBench();
                break;
            default:
                if (p.id == 0)
                {
                    MoveToBench();
                    return;
                }
                this.gameObject.transform.SetParent(team.playerPoolHandler.playerPool.transform);
                rostered = false;
                break;
        }

        UpdateText();
    }

    public void MoveLeft()
    {
        this.transform.SetAsFirstSibling();
        p.slotAct = (ushort) transform.GetSiblingIndex();
        UpdateText();
    }

    public void MoveRight()
    {
        this.transform.SetAsLastSibling();
        p.slotAct = (ushort)transform.GetSiblingIndex();
        UpdateText();
    }

    public void MoveToBench()
    {
        this.transform.SetParent(team.roster.transform);
        rostered = true;
    }

    public void RemoveFromRoster()
    {
        this.transform.SetParent(team.playerPoolHandler.transform);
        rostered = false;
    }

    private void onPlayerSelected()
    {
        if (rostered == false)
        {
            MoveToBench();
        }
        else
        {
            selected = !selected;
            //team.panel_playerSettings.ShowPanel(this);
        }
        UpdateText();
    }
*/

