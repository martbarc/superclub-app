
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Player
{
    public string firstName;
    public string position;
    public int power;

    public string positionAct;
    public int perferredSlot;

    public bool init;

    public Player()
    {
        firstName = "Default";
        position = "Att";
        power = 0;

        positionAct = "Bench";
        perferredSlot = 0;

        init = false;
    }

    public Player(string name, string pos, int power)
    {
        this.firstName = name;
        this.position = pos;
        this.power = power;

        positionAct = "Bench";
        perferredSlot = 0;

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
