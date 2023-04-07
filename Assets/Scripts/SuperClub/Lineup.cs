using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lineup : MonoBehaviour
{
    [SerializeField] public GameObject prefab_playercard;
    [SerializeField] public CardSlot prefab_cardslot;

    [SerializeField] public Team team;

    //UI
    [SerializeField] public TextMeshPro text_att;
    [SerializeField] public TextMeshPro text_mid;
    [SerializeField] public TextMeshPro text_def;
    [SerializeField] public GameObject FieldObject;
    [SerializeField] public GameObject BenchObject;

    public List<CardSlot> allSlots;
    [SerializeField] public CardSlot developPlayerSlot;
    [SerializeField] public CardSlot sellPlayerSlot;
    private List<CardSlot> attSlots;
    private List<CardSlot> midSlots;
    private List<CardSlot> defSlots;
    
    private List<CardSlot> benSlots_0;
    private List<CardSlot> benSlots_1;
    private List<CardSlot> benSlots_2;

    public List<Player> attP;
    public List<Player> midP;
    public List<Player> defP;
    public List<Player> benP;

    public float att = 0;
    public float mid = 0;
    public float def = 0;
    public float totalStars = 0;

    // Private
    private Chem lastChem = Chem.None;
    private Player lastP;
    private float _slotOffsetPosition = 15f;
    private bool benchView;

    void Awake()
    {
        allSlots = new List<CardSlot>();
    }

    void Start()
    {
        float fieldx = FieldObject.transform.position.x - (2 * _slotOffsetPosition); //right of text
        float fieldy = FieldObject.transform.position.y;
        attSlots = GenerateRow("AttSlot", Pos.Attacker, FieldObject, 4, fieldx, fieldy + text_att.transform.position.y);
        midSlots = GenerateRow("MidSlot", Pos.Midfielder, FieldObject, 5, fieldx, fieldy + text_mid.transform.position.y);
        defSlots = GenerateRow("DefSlot", Pos.Defender, FieldObject, 5, fieldx, fieldy + text_def.transform.position.y);
        defSlots[0].Init(Pos.Goalie);

        //bench (16 slots + 11 extra (overfill???) = 27)
        float benchx = BenchObject.transform.position.x - (3 * _slotOffsetPosition);
        float benchy = BenchObject.transform.position.y;
        benSlots_0 = GenerateRow("Ben0Slot", Pos.Bench, BenchObject, 7, benchx, benchy + text_att.transform.position.y);
        benSlots_1 = GenerateRow("Ben1Slot", Pos.Bench, BenchObject, 7, benchx, benchy + text_mid.transform.position.y);
        benSlots_2 = GenerateRow("Ben2Slot", Pos.Bench, BenchObject, 7, benchx, benchy + text_def.transform.position.y);

        benchView = true; //Switch to field view
        SwitchLineupView();

        allSlots.Add(developPlayerSlot);
        allSlots.Add(sellPlayerSlot);

        team.Recalc(); //Runs this Recalc() function also
    }

    public bool AddPlayerToLineup(Player p)
    {
        team.teamFunds -= p.tval;

        // setup position find slot in bench
        foreach (CardSlot s in benSlots_0)
        {
            if (s.card == null)
            {
                CreatePlayerCard(p, s.transform.position);
                return true;
            }
        }
        foreach (CardSlot s in benSlots_1)
        {
            if (s.card == null)
            {
                CreatePlayerCard(p, s.transform.position);
                return true;
            }
        }
        foreach (CardSlot s in benSlots_2)
        {
            if (s.card == null)
            {
                CreatePlayerCard(p, s.transform.position);
                return true;
            }
        }

        return false;
    }

    public void RefreshPlayers()
    {
        attP = new List<Player>(); // { null, null, null, null };
        midP = new List<Player>(); // { null, null, null, null, null };
        defP = new List<Player>(); // { null, null, null, null, null };
        benP = new List<Player>();

        //Att
        foreach (CardSlot s in attSlots)
        {
            if (s.card != null)
            {
                attP.Add(s.card.p);
            }
            else
            {
                attP.Add(null);
            }
        }

        //Mid
        foreach (CardSlot s in midSlots)
        {
            if (s.card != null)
            {
                midP.Add(s.card.p);
            }
            else
            {
                midP.Add(null);
            }
        }

        //Def
        foreach (CardSlot s in defSlots)
        {
            if (s.card != null)
            {
                defP.Add(s.card.p);
            }
            else
            {
                defP.Add(null);
            }
        }

        //Bench
        foreach (CardSlot s in benSlots_0)
        {
            if (s.card != null)
            {
                benP.Add(s.card.p);
            }
        }

        foreach (CardSlot s in benSlots_1)
        {
            if (s.card != null)
            {
                benP.Add(s.card.p);
            }
        }

        foreach (CardSlot s in benSlots_2)
        {
            if (s.card != null)
            {
                benP.Add(s.card.p);
            }
        }
    }

    //Returns power from target position and adds it to total stars
    private float AddToPower(Pos pos, Player p)
    {
        float ret = 0f;

        if (p != null)
        {
            if (pos != Pos.Bench)
            {
                ret = p.GetPositionPower(pos);

                if (lastChem == Chem.Right || lastChem == Chem.Both)
                {
                    if (p.GetChem() == Chem.Left || p.GetChem() == Chem.Both)
                    {
                        ret += 1f;
                    }
                }
            }
            
            totalStars += p.pow;
            lastChem = p.GetChem();
        }
        else
        {
            lastChem = Chem.None;
        }

        return ret;
    }

    public void Recalc()
    {
        lastChem = Chem.None;
        totalStars = 0;
        att = team.attBonus; //0f;
        mid = team.midBonus;
        def = team.defBonus;

        RefreshPlayers();

        //Att
        foreach (Player p in attP)
        {
            att += AddToPower(Pos.Attacker, p);
        }
        lastChem = Chem.None;

        //Mid
        foreach (Player p in midP)
        {
            mid += AddToPower(Pos.Midfielder, p);
        }
        lastChem = Chem.None;

        //Def
        foreach (Player p in defP)
        {
            def += AddToPower(Pos.Defender, p);
        }
        lastChem = Chem.None;

        if (defP[0] == null)
        {
            def += 1;
        }

        //bench
        foreach (Player p in benP)
        {
            AddToPower(Pos.Bench, p);
        }

        UpdateText();
    }

    public void UpdateText()
    {
        text_att.text = $"{att}";
        text_mid.text = $"{mid}";
        text_def.text = $"{def}";
    }

    public bool MovePlayerCardToBench(GameObject playerGameObject)
    {
        PlayerCard pCard = playerGameObject.GetComponent<PlayerCard>();
        // setup position find slot in bench
        foreach(CardSlot s in benSlots_0)
        {
            if (s.card == null)
            {
                return s.SlotCard(playerGameObject, false);
            }
        }
        foreach(CardSlot s in benSlots_1)
        {
            if (s.card == null)
            {
                return s.SlotCard(playerGameObject, false);
            }
        }
        foreach(CardSlot s in benSlots_2)
        {
            if (s.card == null)
            {
                return s.SlotCard(playerGameObject, false);
            }
        }

        return false;
    }

    public void SwitchLineupView()
    {
        benchView = !benchView;
        SetBenchView(benchView);
    }

    public void SetBenchView(bool e)
    {
        benchView = e;
        if (benchView)
        {
            EnableFieldObject(false);
            EnableBenchObject(true);
        }
        else
        {
            EnableFieldObject(true);
            EnableBenchObject(false);
        }
    }

    public void EnableFieldObject(bool e)
    {
        foreach(CardSlot s in attSlots)
        {
            s.gameObject.SetActive(e);
        }
        foreach(CardSlot s in midSlots)
        {
            s.gameObject.SetActive(e);
        }
        foreach(CardSlot s in defSlots)
        {
            s.gameObject.SetActive(e);
        }
        FieldObject.SetActive(e);
    }

    public void EnableBenchObject(bool e)
    {
        foreach(CardSlot s in benSlots_0)
        {
            s.gameObject.SetActive(e);
        }
        foreach(CardSlot s in benSlots_1)
        {
            s.gameObject.SetActive(e);
        }
        foreach(CardSlot s in benSlots_2)
        {
            s.gameObject.SetActive(e);
        }
        BenchObject.SetActive(e);
    }

    private GameObject CreatePlayerCard(Player p, Vector2 position)
    {
        SetBenchView(true);

        GameObject newPlayerCard = Instantiate(prefab_playercard, position, Quaternion.identity);
        //Init player in object
        newPlayerCard.name = p.n;
        newPlayerCard.GetComponent<PlayerCard>().InitPlayer(p, team);
        newPlayerCard.GetComponent<PlayerCard>().dragger.CheckDropSlots();

        //Debug.Log("Loaded player: " + n + " " + position);
        return newPlayerCard;
    }

    private List<CardSlot> GenerateRow(string name, Pos pos, GameObject parent, int width, float offset_x, float offset_y) 
    { // offset_x >= 1f offset_y >= 1f
        List<CardSlot> cslots = new List<CardSlot>();
        //int y = 1;
        float yl = offset_y;

        for (int x = 0; x < width; x++) {
            float xl = (x * _slotOffsetPosition) + offset_x;

            var spawnedSlot = Instantiate(prefab_cardslot, new Vector3(xl, yl), Quaternion.identity);
            spawnedSlot.transform.SetParent(parent.transform);
            spawnedSlot.name = $"{name}_{x}";

            //Debug.Log($"{spawnedSlot.name} spawned: x[{xl}] y[{yl}]");

            spawnedSlot.Init(pos);

            cslots.Add(spawnedSlot);
            allSlots.Add(spawnedSlot);
        }
        return cslots;
    }

    private bool SetLocalPlayerVarFromSlot(CardSlot s)
    {
        if (s.cardObj == null) return false;

        lastP = s.cardObj.GetComponent<PlayerCard>().p;
        if (lastP == null) return false;

        lastChem = lastP.GetChem();

        return true;
    }
}

    // [SerializeField] public TMP_Dropdown dropdown_Formation;
    // [SerializeField] public GameObject prefab_lineupSlot;
    // public List<GameObject> lineupSlotList;

    // [SerializeField] public Team team;

    // [SerializeField] public GameObject panel_attackers;
    // [SerializeField] public GameObject panel_middies;
    // [SerializeField] public GameObject panel_defense;
    // [SerializeField] public GameObject panel_goalie;

    // public int MAX_PLAYERS = 11;

    // public List<Player> attackers;
    // public List<Player> middies;
    // public List<Player> defenders;
    // public Player goalie;

    // public float att = 0;
    // public float mid = 0;
    // public float def = 0;
    // public float totalPower = 0;

    // private void Awake()
    // {
    //     dropdown_Formation.onValueChanged.AddListener(delegate {SetFormation(); });

    //     lineupSlotList = new List<GameObject>();

    //     attackers = new List<Player>();
    //     middies = new List<Player>();
    //     defenders = new List<Player>();
    //     goalie = null;
    // }

    // // Start is called before the first frame update
    // void Start()
    // {
    //     SetFormation();
    // }

    // public void ClearFormation()
    // {
    //     foreach(GameObject g in lineupSlotList)
    //     {
    //         g.GetComponent<LineupSlot>().BenchPlayer();
    //     }

    //     lineupSlotList = new List<GameObject>();

    //     // clear place holders
    //     foreach (Transform child in panel_goalie.transform)
    //     {
    //         GameObject.Destroy(child.gameObject);
    //     }
    //     foreach (Transform child in panel_defense.transform)
    //     {
    //         GameObject.Destroy(child.gameObject);
    //     }
    //     foreach (Transform child in panel_middies.transform)
    //     {
    //         GameObject.Destroy(child.gameObject);
    //     }
    //     foreach (Transform child in panel_attackers.transform)
    //     {
    //         GameObject.Destroy(child.gameObject);
    //     }
    // }

    // public void SetFormation()
    // {
    //     ClearFormation();

    //     string selectedText = dropdown_Formation.options[dropdown_Formation.value].text;
    //     List<GameObject> pInFormation = team.GetFormationSetting(selectedText);

    //     string[] positions = selectedText.Split('-');
    //     if (positions.Length != 3)
    //     {
    //         Debug.Log("ERROR: Can't read formation");
    //         return;
    //     }

    //     int numDef = Int32.Parse(positions[0]);
    //     int numMid = Int32.Parse(positions[1]);
    //     int numAtt = Int32.Parse(positions[2]);

    //     //slot 0 = goalie
    //     for (int i = 0; i < MAX_PLAYERS; i++)
    //     {
    //         GameObject newSlot = Instantiate(prefab_lineupSlot, transform.position, Quaternion.identity);
    //         newSlot.GetComponent<LineupSlot>().formation = selectedText;
    //         newSlot.GetComponent<LineupSlot>().slot = i;
    //         newSlot.GetComponent<LineupSlot>().UpdateText();
    //         newSlot.GetComponent<LineupSlot>().team = team;

    //         //Assign to proper parent
    //         if (i == 0) // goalie
    //         {
    //             newSlot.transform.SetParent(panel_goalie.transform);
    //         }
    //         else if (i > 0 && i <= numDef) //defense 1, 2, 3, 4
    //         {
    //             newSlot.transform.SetParent(panel_defense.transform);
    //         }
    //         else if (i > numDef && i <= numDef + numMid) //mid 5, 6 ,6, 8
    //         {
    //             newSlot.transform.SetParent(panel_middies.transform);
    //         }
    //         else if (i > numDef + numMid && i < MAX_PLAYERS) //offense 9, 10
    //         {
    //             newSlot.transform.SetParent(panel_attackers.transform);
    //         }

    //        lineupSlotList.Add(newSlot);

    //         //Debug.Log("Loaded new game card");
    //     }

    //     foreach (GameObject s in lineupSlotList)
    //     {
    //         foreach(GameObject g in pInFormation) //Check if any player is already tied to formation
    //         {
    //             PlayerObj pObj = g.GetComponent<PlayerObj>();
    //             int slot = pObj.p.formationSetting[selectedText];

    //             if (s.GetComponent<LineupSlot>().slot == slot)
    //             {
    //                 s.GetComponent<LineupSlot>().SlotPlayer(g);
    //             }
    //         }
    //     }


    //     Recalc();
    // }

    // public void AssignPlayerToPosition(GameObject g)
    // {
    //     PlayerObj pObj = g.GetComponent<PlayerObj>();
    //     //int slot = 
    // }

    // public int Recalc()
    // {
    //     attackers = GetChildrenInPosition(panel_attackers);
    //     middies = GetChildrenInPosition(panel_middies);
    //     defenders = GetChildrenInPosition(panel_defense);
    //     goalie = GetChildrenInPosition(panel_goalie)[0];

    //     //Calc power
    //     att = 0f;
    //     mid = 0f;
    //     def = 0f;
    //     totalPower = 0;

    //     Chem lastChem = Chem.None;
    //     if (attackers[0] != null)
    //     {
    //         foreach (Player p in attackers)
    //         {
    //             if ((lastChem == Chem.Right || lastChem == Chem.Both) 
    //             && (p.GetChem() == Chem.Left || p.GetChem() == Chem.Both))
    //             {
    //                 att += 1;
    //             }
    //             att += p.GetPositionPower(Pos.Attacker);
    //             totalPower += p.pow;

    //             lastChem = p.GetChem();
    //         }
    //     }

    //     lastChem = Chem.None;
    //     if (middies[0] != null)
    //     {
    //         foreach (Player p in middies)
    //         {
    //             if ((lastChem == Chem.Right || lastChem == Chem.Both)
    //                 && (p.GetChem() == Chem.Left || p.GetChem() == Chem.Both))
    //             {
    //                 mid += 1;
    //             }
    //             mid += p.GetPositionPower(Pos.Midfielder);
    //             totalPower += p.pow;

    //             lastChem = p.GetChem();
    //         }
    //     }

    //     lastChem = Chem.None;
    //     if (goalie != null)
    //     {
    //         def += goalie.GetPositionPower(Pos.Goalie);
    //         totalPower += goalie.pow;

    //         lastChem = goalie.GetChem();
    //     }

    //     if (defenders[0] != null)
    //     {
    //         foreach (Player p in defenders)
    //         {
    //             if ((lastChem == Chem.Right|| lastChem == Chem.Both)
    //                 && (p.GetChem() == Chem.Left || p.GetChem() == Chem.Both))
    //             {
    //                 def += 1;
    //             }
    //             def += p.GetPositionPower(Pos.Defender);
    //             totalPower += p.pow;

    //             lastChem = p.GetChem();
    //         }
    //     }

    //     return 0;
    // }

    // public List<Player> GetChildrenInPosition(GameObject position)
    // {
    //     int totalElements = position.transform.childCount;

    //     List<Player> gObjs = new List<Player>();

    //     for (int i = 0; i < totalElements; i++)
    //     {
    //         PlayerObj pTemp = position.transform.GetChild(i).GetComponent<PlayerObj>();

    //         if(pTemp != null)
    //         {
    //             gObjs.Add(pTemp.p);
    //         }
    //     }

    //     if (gObjs.Count == 0)
    //     {
    //         //Debug.Log("Error: No players in position!");
    //         gObjs.Add(null);
    //     }

    //     return gObjs;
    // }