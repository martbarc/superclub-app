using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

public class Lineup : MonoBehaviour
{
    [SerializeField] public List<DropSlot> slots;

    public List<Vector3> slotsPos;

    void Awake()
    {
        slotsPos = new List<Vector3>();
        foreach(DropSlot p in slots)
        {
            slotsPos.Add(p.transform.position);
        }
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