
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Player
{
    public string firstName;
    public string position;
    public int power;

    public string positionAct;
    public int slotAct;

    public bool init;

    public Player()
    {
        firstName = "Default";
        position = "Att";
        power = 0;

        positionAct = "Bench";
        slotAct = 0;

        init = false;
    }

    public Player(string name, string pos, int power)
    {
        this.firstName = name;
        this.position = pos;
        this.power = power;

        positionAct = "Bench";
        slotAct = 0;

        init = true;
    }

    public void CopyPlayer(Player p)
    {
        firstName = p.firstName;
        position = p.position;
        power = p.power;

        positionAct = p.positionAct;
    }
}
