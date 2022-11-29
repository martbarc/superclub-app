using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Team : MonoBehaviour
{
    // PUBLIC SETTINGS
    [SerializeField] public Lineup lineup;
    [SerializeField] public Roster roster;
    [SerializeField] public PlayerPoolHandler playerPool;

    // HOME PANEL
    [SerializeField] public Button button_playGame;
    [SerializeField] public TextMeshProUGUI text_game;
    [SerializeField] public TextMeshProUGUI text_teamStats;

    //Panels
    [SerializeField] public GameObject panel_home;
    [SerializeField] public GameObject panel_roster;
    [SerializeField] public GameObject panel_lineup;
    [SerializeField] public GameObject panel_season;
    [SerializeField] public GameObject panel_playerpool;

    //Bottom Tabs
    [SerializeField] public Button button_home;
    [SerializeField] public Button button_roster;
    [SerializeField] public Button button_lineup;
    [SerializeField] public Button button_season;
    [SerializeField] public Button button_add;
    [SerializeField] public Button button_Update;


    public float totalPower;

    public int gameNum;

    int rollAtt0;
    int rollAtt1;

    int rollMid0;
    int rollMid1;

    int rollDef0;
    int rollDef1;

    public float simAtt;
    public float simMid;
    public float simDef;

    public string gameText;

    private void Awake()
    {
        button_Update.onClick.AddListener(UpdateAll);

        button_home.onClick.AddListener(ShowHome);
        button_roster.onClick.AddListener(ShowRoster);
        button_lineup.onClick.AddListener(ShowLineup);
        button_season.onClick.AddListener(ShowSeason);
        button_add.onClick.AddListener(ShowPlayerPool);

        button_playGame.onClick.AddListener(PlayGame);

        totalPower = 0;
    }

    private void Start()
    {
        ResetGame();
        ShowHome();

        UpdateTeamStatsText();
    }

    private void UpdateAll()
    {
        lineup.Recalc();
        roster.Recalc();

        totalPower = lineup.totalPower + roster.totalPower;

        UpdateTeamStatsText();
    }

    public void UpdateTeamStatsText()
    {
        text_teamStats.text = $"Att: {lineup.att}\n" +
         $"Mid: {lineup.mid} - Def: {lineup.def}" +
            $"\nTotal: {totalPower}";
    }

    //Panel controller
    public void HideAll()
    {
        panel_home.gameObject.SetActive(false);
        panel_roster.gameObject.SetActive(false);
        panel_lineup.gameObject.SetActive(false);
        panel_season.gameObject.SetActive(false);
        panel_playerpool.gameObject.SetActive(false);
    }

    public void ShowHome()
    {
        HideAll();
        panel_home.gameObject.SetActive(true);
    }

    public void ShowRoster()
    {
        HideAll();
        panel_roster.gameObject.SetActive(true);
    }

    public void ShowLineup()
    {
        HideAll();
        panel_lineup.gameObject.SetActive(true);
    }

    public void ShowSeason()
    {
        HideAll();
        panel_season.gameObject.SetActive(true);
    }

    public void ShowPlayerPool()
    {
        HideAll();
        panel_playerpool.gameObject.SetActive(true);
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

        simAtt = rollAtt0 + rollAtt1 + lineup.att;
        simMid = rollMid0 + rollMid1 + lineup.mid;
        simDef = rollDef0 + rollDef1 + lineup.def;

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
            $"Att: {simAtt} = {rollAtt0} + {rollAtt1} + {lineup.att}\n" +
            $"Mid: {simMid} = {rollMid0} + {rollMid0} + {lineup.mid}\n" +
            $"Def: {simDef} = {rollDef0} + {rollDef1} + {lineup.def}\n";
    }

    public void UpdateText()
    {
        if (text_game != null)
        {
            text_game.text = gameText;
        }
    }
}
