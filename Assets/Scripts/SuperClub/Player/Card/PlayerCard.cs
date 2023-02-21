using UnityEngine;
using TMPro;

public class PlayerCard : MonoBehaviour
{
    // UI
    [SerializeField] public SpriteRenderer image_back;
    [SerializeField] public SpriteRenderer image_leftChem;
    [SerializeField] public SpriteRenderer image_rightChem;
    [SerializeField] public TextMeshPro text_name;
    [SerializeField] public TextMeshPro text_power;
    [SerializeField] public TextMeshPro text_stats;
    [SerializeField] public TextMeshPro text_value;

    // OBJ
    [SerializeField] public CardDragger dragger;

    public Player p;
    public Team team;

    void Awake()
    {
        p = new Player();
    }

    void Start()
    {
        UpdateText();
    }

    public void InitPlayer(Player newP, Team targetTeam)
    {
        p = new Player(newP);
        team = targetTeam;
        dragger.Init(team.lineup.allSlots);

        p.posAct = (ushort)Pos.Bench;

        image_back.color = p.GetPlayerColor();
        (image_leftChem.color, image_rightChem.color) = p.GetPlayerChemColor();

        Debug.Log($"Player_Card {p.n} Initialized");
    }

    public void UpdateText()
    {
        text_name.text = p.n;
        text_power.text = $"{p.pow}";
        text_stats.text = "";
        text_value.text = p.GetValueString();
 
    }

    public void SelectCard(bool s)
    {
        float m = 1.5f;
        byte red = (byte) (image_back.color.r *  255);
        byte green = (byte) (image_back.color.g *  255);
        byte blue = (byte) (image_back.color.b *  255);
        Vector3 objectScale = transform.localScale;

        if (s)
        {
            this.transform.localScale = new Vector3(objectScale.x*m,  objectScale.y*m, objectScale.z*m);
            image_back.color = new Color32(red, green, blue, 160);
        }
        else
        {
            this.transform.localScale = new Vector3(objectScale.x/m,  objectScale.y/m, objectScale.z/m);
            image_back.color = new Color32(red, green, blue, 255);
        }

    }

    public void TriggerPlayerDevelopment()
    {
        this.team.OpenPlayerDevelopment(this);
    }
}

