
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

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

    public bool custom;

    public int CHEM_MAX = 3;
    public int POSITION_MAX = 6;

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
        custom = false;

        GetString();
    }

    public Player(Player newP)
    {
        InitPlayer();

        this.id = newP.id;
        this.n = newP.n;
        this.pos = (ushort)newP.pos;
        this.pow = newP.pow;
        this.chem = (ushort)newP.chem;
        this.tval = newP.tval;
        this.sval = newP.sval;

        init = true;
        custom = false;

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
        custom = false;
    }

    public void InitCustom()
    {
        InitPlayer();

        n = "Custom";

        tval = 0;
        sval = 0;

        init = true;
        custom = true;
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

    public void SetPosVal(ushort v)
    {
        if (v <= POSITION_MAX && v > 0)
        {
            this.pos = v;
        }
        else
        {
            this.pos = 0;
        }
    }

    public Chem GetChem()
    {
        return (Chem)chem;
    }

    public void SetChemVal(ushort v)
    {
        if (v <= CHEM_MAX && v > 0)
        {
            this.chem = v;
        }
        else
        {
            this.chem = 0;
        }
    }

    public Pos GetPosAct()
    {
        return (Pos)posAct;
    }

    public void SetPosAct(Pos position)
    {
        this.posAct = (ushort)position;
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

    public Color32 GetPlayerColor()
    {
        switch (GetPos())
        {
            case Pos.Attacker:
                return new Color32(131, 255, 131, 255);
            case Pos.Midfielder:
                return new Color32(255, 255, 131, 255);
            case Pos.Defender:
                return new Color32(255, 133, 131, 255);
            case Pos.Goalie:
                return new Color32(171, 171, 171, 255);
            case Pos.Wild:
                return new Color32(175, 131, 255, 255);
            default:
                return new Color32(255, 255, 255, 255);
        }
    }

    // Left, right
    public (Color32, Color32) GetPlayerChemColor()
    {
        switch (GetChem())
        {
            case Chem.None:
                return (new Color32(0, 0, 0, 0), new Color32(0, 0, 0, 0));
            case Chem.Left:
                return (new Color32(0, 0, 0, 200), new Color32(0, 0, 0, 0));
            case Chem.Right:
                return (new Color32(0, 0, 0, 0), new Color32(0, 0, 0, 200));
            case Chem.Both:
                return (new Color32(0, 0, 0, 200), new Color32(0, 0, 0, 200));
            default:
                return (new Color32(0, 0, 0, 0), new Color32(0, 0, 0, 0));
        }
    }

    public int GetPowInt()
    {
        return (int)this.pow;
    }

    public List<string> GetPosList()
    {
        return new List<string>
        {
            "Unsigned",
            "Bench",
            "Wild",
            "Attacker",
            "Midfielder",
            "Defender",
            "Goalie"
        };
    }

    public List<string> GetChemList()
    {
        return new List<string>
        {
            "None",
            "Left",
            "Right",
            "Both"
        };
    }
}
