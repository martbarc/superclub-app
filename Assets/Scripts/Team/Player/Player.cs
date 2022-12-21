
using System.Collections;
using System.Collections.Generic;
using System;

public enum Pos : ushort
{
    Unsigned = 0,
    Bench = 1,
    Wild = 2,
    Attacker = 3,
    Midfielder = 4,
    Defender = 5,
    Goalie = 6
}

public enum Chem : ushort
{
    None = 0,
    Left = 1,
    Right = 2,
    Both = 3
}

[System.Serializable]
public class Player
{
    // SERIALIZABLE PARAM
    public ushort id; //name or id
    public string n; //name
    public ushort pos; //position
    public float pow; //current power
    public float mpow; //max power
    public ushort chem; //chemistry
    public ushort tval; //trade value
    public ushort sval; //scout value
    public ushort game; //base game (0) or expansion (1+)?

    // NONSERIALIZABLE PARAM
    public Dictionary<string, int> formationSetting;
    public ushort posAct; //actual position
    public ushort slotAct; //slot number

    public bool init;
    public string playerString;

    public Player()
    {
        InitPlayer();
    }

    public Player(ushort id, string name, Pos position, float power, Chem chemistry, ushort tval, ushort sval)
    {
        InitPlayer();

        this.id = id;
        this.n = name;
        this.pos = (ushort)position;
        this.pow = power;
        this.chem = (ushort)chemistry;
        this.tval = tval;
        this.sval = sval;

        init = true;

        GetString();
    }

    public void InitPlayer()
    {
        id = 0;
        n = "Default";
        pos = 2;
        pow = 1f;
        mpow = 0f;
        chem = 0;
        tval = 2;
        sval = 1;
        game = 0;

        formationSetting = new Dictionary<string, int>();
        posAct = 0;
        slotAct = 0;

        init = false;
    }

    public string GetString()
    {
        playerString = $"{pow}"; // pow
        return playerString;
    }

    public string GetStringSummary()
    {
        playerString = $"{n}" + // name
            $"\n{pow}"; // pow
        return playerString;
    }

    public string GetValueString()
    {
        string playerValue = $"T: {tval}M   S: {sval}M";
        return playerValue;
    }

    public Pos GetPos()
    {
        return (Pos)pos;
    }

    public Chem GetChem()
    {
        return (Chem)chem;
    }

    public Pos GetPosAct()
    {
        return (Pos)posAct;
    }

    public float GetPositionPower(Pos tarPos)
    {
        float power = pow;
        Pos p = GetPos();

        if (p == tarPos
            || p == Pos.Wild
            || p == Pos.Goalie)
        {
            return power;
        }
        else // Get difference * .5 of position
        {
            float diff = 0;
            if ( pos > (ushort)tarPos)
            {
                diff = ((pos - (ushort)tarPos)) * 0.5f;
            }
            else
            {
                diff = (((ushort)tarPos) - pos) * 0.5f;
            }
            return power - diff;
        }

        //return power;
    }

    public void SetPosAct(Pos position)
    {
        this.posAct = (ushort)position;
    }
}
