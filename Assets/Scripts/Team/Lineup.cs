using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lineup : MonoBehaviour
{
    public List<Position> positions;

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

    private void Awake()
    {
        positions = new List<Position>();

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

    private void AddToLineup(GameObject pObj)
    {
        if (pObj == null)
        {
            Debug.Log("ERR: pObj null, check internal player list");
            return;
        }

        Player oldStuff = pObj.GetComponent<Player> ();

        GameObject newPlayerObj = Instantiate(pObj);
        Player newPlayer = newPlayerObj.GetComponent<Player>();

        //newPlayer.Init(oldStuff);

        switch (newPlayer.positionAct)
        {
            case "Att":
                newPlayerObj.transform.parent = panel_attackers.transform;
                attackers.Add(newPlayer);
                break;
            case "Mid":
                newPlayerObj.transform.parent = panel_middies.transform;
                middies.Add(newPlayer);
                break;
            case "Def":
                if (newPlayer.position == "G")
                {
                    newPlayerObj.transform.parent = panel_goalie.transform;
                    goalie = newPlayer;
                }
                else
                {
                    newPlayerObj.transform.parent = panel_defense.transform;
                    defenders.Add(newPlayer);
                }
                
                break;
        }

        Debug.Log("Added player to lineup");
    }

    private void ClearLineup()
    {
        attackers = new List<Player>();
        middies = new List<Player>();
        defenders = new List<Player>();
        goalie = null;

        foreach (Transform child in panel_attackers.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in panel_middies.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in panel_defense.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in panel_goalie.transform)
        {
            Destroy(child.gameObject);
        }

    }

    public int Recalc()
    {
        ClearLineup();

        foreach (GameObject pObj in team.roster.playerObjectList)
        {
            Player p = pObj.GetComponent<Player>();

            switch (p.positionAct)
            {
                case "Att":
                case "Mid":
                case "Def":
                    AddToLineup(pObj);
                    break;
            }
        }

        //Calc power
        att = 0;
        mid = 0;
        def = 0;

        foreach (Player p in attackers)
        {
            att += p.power;
        }

        foreach (Player p in middies)
        {
            mid += p.power;
        }

        foreach (Player p in defenders)
        {
            def += p.power;
        }

        if (goalie != null)
        {
            def += goalie.power;
        }
        

        return 0;
    }

    public void AssignPlayerToPosition(Player player, string position)
    {
        switch (position)
        {
            case "Att":
                attackers.Add(player);
                break;
            case "Mid":
                middies.Add(player);
                break;
            case "Def":
                defenders.Add(player);
                break;
            case "G":
                goalie = player;
                break;
        }
    }

    public void AssignPlayerToPosition(Player player, int positionIndex)
    {
        positions[positionIndex].AssignPlayer(player);
    }

}
