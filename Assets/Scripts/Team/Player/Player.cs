
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
    public ushort id; //name or id
    public string n; //name
    public ushort pos; //position
    public float pow; //current power
    public float mpow; //max power
    public ushort chem; //chemistry
    public ushort tval; //trade value
    public ushort sval; //scout value
    public ushort game; //base game (0) or expansion (1+)?

    public ushort posAct; //actual position
    public ushort slotAct; //slot number

    public bool init;

    public string playerString;

    public Player()
    {
        id = 0;
        n = "";
        pos = 0;
        pow = 0f;
        mpow = 0f;
        chem = 0;
        tval = 0;
        sval = 0;
        game = 0;

        posAct = 0;
        slotAct = 0;

        init = false;
    }

    public Player(ushort id, string name, Pos position, float power, Chem chemistry)
    {
        this.id = id;
        this.n = name;
        this.pos = (ushort)position;
        this.pow = power;
        this.chem = (ushort)chemistry;

        posAct = 0;
        slotAct = 0;

        init = true;

        GetString();
    }

    public string GetString()
    {
        playerString = $"{n}" + // name
            $"\n{pow}"; // pow
        return playerString;
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

        return power;
    }

    public void SetPosAct(Pos position)
    {
        this.posAct = (ushort)position;
    }
}
