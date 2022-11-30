using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerObj : MonoBehaviour
{
    [SerializeField] public Image image_back;
    [SerializeField] public Button select;
    [SerializeField] public TextMeshProUGUI text_stats;
    [SerializeField] public TextMeshProUGUI text_value;

    public Player p;
    public Team team;

    public bool selected;
    public bool rostered;

    void Awake()
    {
        p = new Player();
        selected = false;
        rostered = false;

        select.onClick.AddListener(onPlayerSelected);
    }

    void Start()
    {
        UpdateText();
    }

    public void InitPlayer(Team team, ushort id, string name, Pos pos, float power, Chem chem)
    {
        this.team = team;
        p = new Player(id, name, pos, power, chem);

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

        if (p.id == 0)//(p.n == "Given")
        {
            MoveToBench();
        }
    }

    public void AssignToTeam(Team assignedTeam)
    {
        this.team = assignedTeam;
    }

    public void UpdateText()
    {
        text_stats.text = p.GetString();
        //text_slot.text = $"( {perferredSlot} )";
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
                this.gameObject.transform.SetParent(team.playerPool.playerPool.transform);
                rostered = false;
                break;
        }

        UpdateText();
        team.panel_playerselect.HidePanel();
    }

    public void MoveLeft()
    {
        this.transform.SetAsFirstSibling();
        p.slotAct = (ushort) transform.GetSiblingIndex();
        UpdateText();
        team.panel_playerselect.HidePanel();
    }

    public void MoveRight()
    {
        this.transform.SetAsLastSibling();
        p.slotAct = (ushort)transform.GetSiblingIndex();
        UpdateText();
        team.panel_playerselect.HidePanel();
    }

    public void MoveToBench()
    {
        this.transform.SetParent(team.roster.transform);
        rostered = true;
    }

    private void onPlayerSelected()
    {
        if (rostered == false)
        {
            MoveToBench();
        }
        else
        {
            team.panel_playerselect.ShowPanel(this);
        }
    }

}


