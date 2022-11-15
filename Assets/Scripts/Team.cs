using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    // Lineup
    List<Player> attack;
    List<Player> midfield;
    List<Player> defender;

    Player goalie;

    public int att = 0;
    public int mid = 0;
    public int def = 0;

    private void Awake()
    {
        attack = new List<Player>(4);
        midfield = new List<Player>(5);
        defender = new List<Player>(4);
    }

    private void Start()
    {
        
    }

    public int recalc()
    {
        foreach(Player p in attack)
        {
            att += p.getPower();
        }

        foreach(Player p in midfield)
        {
            mid += p.getPower();
        }

        foreach(Player p in defender)
        {
            def += p.getPower();
        }

        def += goalie.getPower();

        return 0;
    }

}
