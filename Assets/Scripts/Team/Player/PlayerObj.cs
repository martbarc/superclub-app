using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerObj : MonoBehaviour
{
    [SerializeField] public Image image_back;
    [SerializeField] public Button select;
    [SerializeField] public TextMeshProUGUI text_stats;

    //Selected panel
    [SerializeField] public GameObject panel_selected;
    //[SerializeField] public Button button_close;

    [SerializeField] public TMP_Dropdown dropdown_positionAct;

    [SerializeField] public Button button_moveLeft;
    [SerializeField] public Button button_moveRight;

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

        dropdown_positionAct.onValueChanged.AddListener(PositionActChanged);
        button_moveLeft.onClick.AddListener(MoveLeft);
        button_moveRight.onClick.AddListener(MoveRight);
    }

    void Start()
    {
        UpdateText();

        HidePanel();
    }

    public void InitPlayer(Team team, string name, string pos, float power, string chem)
    {
        this.team = team;
        p = new Player(name, pos, power, chem);
        switch (p.pos)
        {
            case "Att":
                image_back.color = new Color32(0, 255, 0, 255);
                break;
            case "Mid":
                image_back.color = new Color32(255, 255, 0, 255);
                break;
            case "Def":
                image_back.color = new Color32(255, 0, 0, 255);
                break;
            case "G":
                image_back.color = new Color32(255, 255, 225, 255);
                break;
            default:
                image_back.color = new Color32(255, 255, 225, 255);
                break;
        }


        if (p.id == "Place")
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

    public void SetActive(bool a)
    {
        this.gameObject.SetActive(a);
    }

    //private
    private void PositionActChanged(int arg0)
    {

        p.posAct = dropdown_positionAct.options[dropdown_positionAct.value].text;

        switch(p.posAct)
        {
            case "Att":
                this.gameObject.transform.parent = team.lineup.panel_attackers.transform;
                break;
            case "Mid":
                this.gameObject.transform.parent = team.lineup.panel_middies.transform;
                break;
            case "Def":
                this.gameObject.transform.parent = team.lineup.panel_defense.transform;
                break;
            case "G":
                //Swap current goalie out

                this.gameObject.transform.parent = team.lineup.panel_goalie.transform;
                break;
            case "Bench":
                MoveToBench();
                break;
            default:
                if (p.id == "Place")
                {
                    MoveToBench();
                    return;
                }
                this.gameObject.transform.parent = team.playerPool.playerPool.transform;
                rostered = false;
                break;
        }

        Debug.Log("Player moved to lineup!");

        UpdateText();
        HidePanel();
    }

    public void MoveLeft()
    {
        this.transform.SetAsFirstSibling();
        p.slotAct = transform.GetSiblingIndex();
        UpdateText();
        HidePanel();
    }

    public void MoveRight()
    {
        this.transform.SetAsLastSibling();
        p.slotAct = transform.GetSiblingIndex();
        UpdateText();
        HidePanel();
    }

    public void MoveToBench()
    {
        this.gameObject.transform.parent = team.roster.transform;
        rostered = true;
    }

    private void SlotChanged(int arg0)
    {
        p.slotAct = dropdown_positionAct.value;
        this.transform.SetSiblingIndex(p.slotAct);
        Debug.Log($"Player moved to slot {p.slotAct}");
        UpdateText();
        HidePanel();
    }

    private void onPlayerSelected()
    {
        if (rostered == false)
        {
            MoveToBench();
        }
        else
        {
            ShowPanel();
        }
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


