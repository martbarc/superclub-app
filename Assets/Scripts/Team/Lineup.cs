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

    public int att = 0;
    public int mid = 0;
    public int def = 0;
    public int totalPower = 0;

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
        att = 0;
        mid = 0;
        def = 0;
        totalPower = 0;

        if (attackers[0] != null)
        {
            foreach (Player p in attackers)
            {
                att += p.pow;
                totalPower += p.pow;
            }
        }

        if (middies[0] != null)
        {
            foreach (Player p in middies)
            {
                mid += p.pow;
                totalPower += p.pow;
            }
        }

        if (defenders[0] != null)
        {
            foreach (Player p in defenders)
            {
                def += p.pow;
                totalPower += p.pow;
            }
        }

        if (goalie != null)
        {
            def += goalie.pow;
            totalPower += goalie.pow;
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
