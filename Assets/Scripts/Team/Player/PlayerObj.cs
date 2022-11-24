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

    public void InitPlayer(Team team, string name, string pos, int power)
    {
        this.team = team;
        p = new Player(name, pos, power);
        switch (p.position)
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
        
    }

    public void AssignToTeam(Team assignedTeam)
    {
        this.team = assignedTeam;
    }

    public void UpdateText()
    {
        text_stats.text = $"Name: {p.firstName}" +
            $"\nStars: {p.power}" +
            $"\nPosition: {p.position}" +
            $"\nLineup: {p.positionAct}" +
            $"\nSlot: {p.slotAct}";
        //text_slot.text = $"( {perferredSlot} )";
    }

    public void SetActive(bool a)
    {
        this.gameObject.SetActive(a);
    }

    //private
    private void PositionActChanged(int arg0)
    {
        p.positionAct = dropdown_positionAct.options[dropdown_positionAct.value].text;

        switch(p.positionAct)
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
                this.gameObject.transform.parent = team.lineup.panel_goalie.transform;
                break;
            case "Bench":
                this.gameObject.transform.parent = team.roster.transform;
                break;
            default:
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
            this.gameObject.transform.parent = team.roster.transform;
            rostered = true;
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


