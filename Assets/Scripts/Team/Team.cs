using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Team : MonoBehaviour
{
    // All
    //public List<Player> roster; //11 + 12 = 23

    // Lineup
    public List<Player> attack;
    public List<Player> midfield;
    public List<Player> defender;

    public Player goalie;

    public int att = 0;
    public int mid = 0;
    public int def = 0;

    [SerializeField] public Lineup lineup;
    [SerializeField] public Roster roster;

    [SerializeField] public TextMeshProUGUI text_teamStats;

    private void Awake()
    {
        attack = new List<Player>(4);
        midfield = new List<Player>(5);
        defender = new List<Player>(4);

        goalie = new Player();
    }

    private void Start()
    {
        Recalc();
        UpdateTeamStatsText();
    }

    public int Recalc()
    {
        foreach(Player p in attack)
        {
            att += p.power;
        }

        foreach(Player p in midfield)
        {
            mid += p.power;
        }

        foreach(Player p in defender)
        {
            def += p.power;
        }

        def += goalie.power;

        return 0;
    }

    public void UpdateTeamStatsText()
    {
        text_teamStats.text = $"Att: {att}\nMid: {mid}\nDef: {def}\nTotal: {roster.totalPower}";
    }

    //Panel controller
}
