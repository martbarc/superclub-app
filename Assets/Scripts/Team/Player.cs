
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] public Button select;
    [SerializeField] public TextMeshProUGUI text_stats;

    //Selected panel
    [SerializeField] public GameObject panel_selected;
    [SerializeField] public Button button_close;

    [SerializeField] public Button button_att;
    [SerializeField] public Button button_mid;
    [SerializeField] public Button button_def;
    [SerializeField] public Button button_bench;

    [SerializeField] public Button button_incSlot;
    [SerializeField] public Button button_decSlot;

    [SerializeField] public TextMeshProUGUI text_slot;

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

        button_close.onClick.AddListener(HidePanel);
        select.onClick.AddListener(ShowPanel);

        button_att.onClick.AddListener(MoveToAtt);
        button_mid.onClick.AddListener(MoveToMid);
        button_def.onClick.AddListener(MoveToDef);
        button_bench.onClick.AddListener(MoveToBench);

        button_incSlot.onClick.AddListener(IncSlotNum);
        button_decSlot.onClick.AddListener(DecSlotNum);
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
        text_slot.text = $"( {perferredSlot} )";
    }

    //private

    private void DecSlotNum()
    {
        if (perferredSlot <= 0)
        {
            perferredSlot = 0;
            return;
        }

        perferredSlot -= 1;
        UpdateText();
    }

    private void IncSlotNum()
    {
        perferredSlot += 1;
        UpdateText();
    }

    private void MoveToAtt()
    {
        positionAct = "Att";
        UpdateText();
    }

    private void MoveToMid()
    {
        positionAct = "Mid";
        UpdateText();
    }

    private void MoveToDef()
    {
        positionAct = "Def";
        UpdateText();
    }

    private void MoveToBench()
    {
        positionAct = "Bench";
        UpdateText();
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
