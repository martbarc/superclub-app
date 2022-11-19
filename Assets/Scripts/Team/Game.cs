using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] public Button button_playGame;
    [SerializeField] public TextMeshProUGUI text_game;

    [SerializeField] public Team team;

    public int gameNum;

    int rollAtt0;
    int rollAtt1;

    int rollMid0;
    int rollMid1;

    int rollDef0;
    int rollDef1;

    public int simAtt;
    public int simMid;
    public int simDef;

    public string gameText;

    private void Awake()
    {
        button_playGame.onClick.AddListener(PlayGame);
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        gameNum = 0; 
    }

    public void PlayGame()
    {
        gameNum++;

        rollAtt0 = RollD6();
        rollAtt1 = RollD6();
        
        rollMid0 = RollD6();
        rollMid1 = RollD6();

        rollDef0 = RollD6();
        rollDef1 = RollD6();

        simAtt = rollAtt0 + rollAtt1 + team.lineup.att;
        simMid = rollMid0 + rollMid1 + team.lineup.mid;
        simDef = rollDef0 + rollDef1 + team.lineup.def;

        ResetText();

        if (rollAtt0 == rollAtt1) 
        {
            gameText += $"*Injured Player: Att_{rollAtt0}\n";
        }

        if (rollMid0== rollMid1)
        {
            gameText += $"*Injured Player: Mid_{rollMid0}\n";
        }

        if (rollDef0 == rollDef1)
        {
            gameText += $"*Injured Player: Def_{rollDef0}\n";
        }

        UpdateText();
    }

    public int RollD6()
    {
        return Random.Range(1, 6);
    }

    public void ResetText()
    {
        gameText = $"Game: {gameNum}\n" +
            "Pos: Total = Roll1 + Roll2 + Lineup\n" + 
            $"Att: {simAtt} = {rollAtt0} + {rollAtt1} + {team.lineup.att}\n" +
            $"Mid: {simMid} = {rollMid0} + {rollMid0} + {team.lineup.mid}\n" +
            $"Def: {simDef} = {rollDef0} + {rollDef1} + {team.lineup.def}\n";
    }

    public void UpdateText()
    {
        if (text_game != null)
        {
            text_game.text = gameText;
        }
    }
}
