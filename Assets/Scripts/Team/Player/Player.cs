
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Player
{
    public string id;
    public string pos;
    public int pow;
    public string chem;

    public string posAct;
    public int slotAct;

    public bool init;

    public string playerString;

    public Player()
    {
        id = "Default";
        pos = "Att";
        pow = 0;
        chem = "";

        posAct = "Bench";
        slotAct = 0;

        init = false;
    }

    public Player(string name, string position, int power, string chemistry)
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

    public void CopyPlayer(Player p)
    {
        id = p.id;
        pos = p.pos;
        pow = p.pow;

        posAct = p.posAct;
    }

}
