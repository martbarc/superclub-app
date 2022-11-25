using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lineup : MonoBehaviour
{
    [SerializeField] public Team team;

    [SerializeField] public GameObject panel_attackers;
    [SerializeField] public GameObject panel_middies;
    [SerializeField] public GameObject panel_defense;
    [SerializeField] public GameObject panel_goalie;

    public List<Player> attackers;
    public List<Player> middies;
    public List<Player> defenders;
    public Player goalie;

    public float att = 0;
    public float mid = 0;
    public float def = 0;
    public float totalPower = 0;

    private void Awake()
    {
        attackers = new List<Player>();
        middies = new List<Player>();
        defenders = new List<Player>();
        goalie = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        Recalc();
    }


    public int Recalc()
    {
        attackers = GetChildrenInPosition(panel_attackers);
        middies = GetChildrenInPosition(panel_middies);
        defenders = GetChildrenInPosition(panel_defense);
        goalie = GetChildrenInPosition(panel_goalie)[0];

        //Calc power
        att = 0f;
        mid = 0f;
        def = 0f;
        totalPower = 0;

        string lastChem = "";
        if (attackers[0] != null)
        {
            foreach (Player p in attackers)
            {
                if (lastChem.Contains("R") && p.chem.Contains("L"))
                {
                    att += 1;
                }
                att += p.GetPositionPower("Att");
                totalPower += p.pow;

                lastChem = p.chem;
            }
        }

        lastChem = "";
        if (middies[0] != null)
        {
            foreach (Player p in middies)
            {
                if (lastChem.Contains("R") && p.chem.Contains("L"))
                {
                    mid += 1;
                }
                mid += p.GetPositionPower("Mid");
                totalPower += p.pow;

                lastChem = p.chem;
            }
        }

        lastChem = "";
        if (goalie != null)
        {
            def += goalie.GetPositionPower("G");
            totalPower += goalie.pow;

            lastChem = goalie.chem;
        }

        if (defenders[0] != null)
        {
            foreach (Player p in defenders)
            {
                if (lastChem.Contains("R") && p.chem.Contains("L"))
                {
                    def += 1;
                }
                def += p.GetPositionPower("Def");
                totalPower += p.pow;

                lastChem = p.chem;
            }
        }


        

        return 0;
    }

    public List<Player> GetChildrenInPosition(GameObject position)
    {
        int totalElements = position.transform.childCount;

        List<Player> gObjs = new List<Player>();

        for (int i = 0; i < totalElements; i++)
        {
            PlayerObj pTemp = position.transform.GetChild(i).GetComponent<PlayerObj>();

            if(pTemp != null)
            {
                gObjs.Add(pTemp.p);
            }
        }

        if (gObjs.Count == 0)
        {
            Debug.Log("Error: No players in position!");
            gObjs.Add(null);
        }

        return gObjs;
    }

}
