
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Player
{
    public string id;
    public string pos;
    public float pow;
    public string chem;

    public string posAct;
    public int slotAct;

    public bool init;

    public string playerString;

    public Player()
    {
        id = "Default";
        pos = "Att";
        pow = 0f;
        chem = "";

        posAct = "Bench";
        slotAct = 0;

        init = false;
    }

    public Player(string name, string position, float power, string chemistry)
    {
        this.id = name;
        this.pos = position;
        this.pow = power;
        this.chem = chemistry;

        posAct = "Bench";
        slotAct = 0;

        init = true;

        GetString();
    }

    public string GetString()
    {
        playerString = $"Name: {id}" +
            $"\nStars: {pow}" +
            $"\nPosition: {pos}" +
            $"\nChemistry: {chem}" +
            $"\nLineup: {posAct}" +
            $"\nSlot: {slotAct}";
        return playerString;
    }

    public float GetPositionPower(string targetPosition)
    {
        float power = pow;

        if (pos == targetPosition || pos == "W" || pos == "G")
        {
            return power;
        }
        else
        {
            switch (pos)
            {
                case "Att":
                    if (targetPosition == "Mid")
                    {
                        power -= 0.5f;
                    }
                    else if (targetPosition == "Def")
                    {
                        power -= 1f;
                    }
                    break;
                case "Mid":
                    if (targetPosition == "Att")
                    {
                        power -= 0.5f;
                    }
                    else if (targetPosition == "Def")
                    {
                        power -= 0.5f;
                    }
                    break;
                case "Def":
                    if (targetPosition == "Mid")
                    {
                        power -= 0.5f;
                    }
                    else if (targetPosition == "Att")
                    {
                        power -= 1f;
                    }
                    break;
                default:
                    
                    break;
            }
        }


        return power;
    }

    public void CopyPlayer(Player p)
    {
        id = p.id;
        pos = p.pos;
        pow = p.pow;

        posAct = p.posAct;
    }

}
