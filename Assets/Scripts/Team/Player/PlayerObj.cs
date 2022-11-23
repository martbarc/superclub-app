using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerObj : MonoBehaviour
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

    public Player p;
    public Team team;

    public bool selected;
    public bool rostered;

    void Awake()
    {
        p = new Player();
        selected = false;

        select.onClick.AddListener(onPlayerSelected);

        dropdown_positionAct.onValueChanged.AddListener(PositionActChanged);
        dropdown_slot.onValueChanged.AddListener(SlotChanged);
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
    }

    public void AssignToTeam(Team assignedTeam)
    {
        this.team = assignedTeam;
    }

    public void UpdateText()
    {
        text_stats.text = $"Name: {p.firstName}\nStars: {p.power}\nPosition: {p.position}\nLineup: {p.positionAct}";
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
        UpdateText();
        HidePanel();
    }

    private void SlotChanged(int arg0)
    {
        p.perferredSlot = dropdown_positionAct.value;
        UpdateText();
        HidePanel();
    }

    private void onPlayerSelected()
    {

        this.gameObject.transform.parent = team.roster.transform;
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


