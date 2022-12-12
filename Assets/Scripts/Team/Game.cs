using System.Collections;
using System.Collections.Generic;

public class Game
{
    public int seasonNum;
    public int gameNum;
    public int teamNum;
    public int winLoss; //Win = 6, loss = 0, tie = 2, not played = -1

    public bool selected;

    public Game()
    {
        seasonNum = 1;
        gameNum = 1;
        teamNum = 1;

        winLoss = -1;

        selected = false;
    }

    public Game(int seasonNum, int gameNum, int teamNum)
    {
        this.seasonNum = seasonNum;
        this.gameNum = gameNum;
        this.teamNum = teamNum;

        winLoss = -1;

        selected = false;
    }

    public void SetWinLoss(int wl)
    {
        this.winLoss = wl;
        selected = false;
    }

    public string GetString()
    {
        string returnStr = "";
        returnStr += $"Season: {seasonNum}\n";
        returnStr += $"Game: {gameNum}\n";
        returnStr += $"Team: {teamNum}\n";
        switch (winLoss)
        {
            case 6:
                returnStr += $"Win [{winLoss}]\n";
                break;
            case 2:
                returnStr += $"Tie [{winLoss}]\n";
                break;
            case 0:
                returnStr += $"Loss [{winLoss}]\n";
                break;
            default: //-1
                returnStr += "Upcoming...\n";
                break;
        }

        if (selected)
        {
            returnStr += "[Selected]\n";
        }

        return returnStr;
    }

    public bool SelectGame()
    {
        selected = !selected;
        return selected;
    }
}
