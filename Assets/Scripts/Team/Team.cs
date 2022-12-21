using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Team : MonoBehaviour
{
    // PUBLIC SETTINGS
    // [SerializeField] public PlayerPool pp;
    [SerializeField] public Lineup lineup;
    // [SerializeField] public Roster roster;
    // [SerializeField] public PlayerPoolHandler playerPoolHandler;

    // // HOME PANEL
    // [SerializeField] public Button button_saveTeam;

    // [SerializeField] public PlayerSelectPanel panel_playerSettings;

    [SerializeField] public SaveManager saveManager;

    public float totalPower;

    //TEAM PARAMS
    public string teamName;

    private void Awake()
    {
        totalPower = 0;
    }

    private void Start()
    {
        //LoadTeam();
    }

    public void Recalc()
    {
        lineup.Recalc();
    }

    public void SaveTeam()
    {
        saveManager.Save();
    }

    public void LoadTeam()
    {
        saveManager.Load();
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Team : MonoBehaviour
{
    // PUBLIC SETTINGS
    // [SerializeField] public PlayerPool pp;
    // [SerializeField] public Lineup lineup;
    // [SerializeField] public Roster roster;
    // [SerializeField] public PlayerPoolHandler playerPoolHandler;

    // // HOME PANEL
    // [SerializeField] public Button button_saveTeam;
    // [SerializeField] public Button button_loadTeam;
    // [SerializeField] public TMP_InputField input_teamName;
    // [SerializeField] public SeasonObj seasonObj; //Contains games for that season
    // [SerializeField] public Button button_playGame;
    // [SerializeField] public TextMeshProUGUI text_teamStats;

    // //Panels
    // [SerializeField] public GameObject panel_home;
    // [SerializeField] public GameObject panel_lineup;
    // [SerializeField] public GameObject panel_playerpool;

    // //Bottom Tabs
    // [SerializeField] public Button button_home;
    // [SerializeField] public Button button_lineup;
    // [SerializeField] public Button button_add;
    // [SerializeField] public Button button_update;

    // [SerializeField] public PlayerSelectPanel panel_playerSettings;

    [SerializeField] public SaveManager saveManager;

    public float totalPower;

    // public int gameNum;

    // int rollAtt0;
    // int rollAtt1;

    // int rollMid0;
    // int rollMid1;

    // int rollDef0;
    // int rollDef1;

    public float simAtt;
    public float simMid;
    public float simDef;

    public string gameText;


    //TEAM PARAMS
    public string teamName;

    private void Awake()
    {
        // if (button_update != null) button_update.onClick.AddListener(Recalc);
        // if (button_saveTeam != null) button_saveTeam.onClick.AddListener(SaveTeam);
        // if (button_loadTeam != null) button_loadTeam.onClick.AddListener(LoadTeam);
        // if (input_teamName != null) input_teamName.onEndEdit.AddListener(delegate {InputField_onNameChange(); });

        // if (button_home != null) button_home.onClick.AddListener(ShowHome);
        // if (button_lineup != null) button_lineup.onClick.AddListener(ShowLineup);
        // if (button_add != null) button_add.onClick.AddListener(ShowPlayerPool);

        //if (button_playGame != null) button_playGame.onClick.AddListener(PlayGame);

        totalPower = 0;
    }

    private void Start()
    {
        // ResetGame();
        // ShowHome();

        LoadTeam();
        Recalc();
    }

    public void SaveTeam()
    {
        saveManager.Save();
    }

    public void LoadTeam()
    {
        saveManager.Load();
    }

    // public void InputField_onNameChange()
    // {
    //     teamName = input_teamName.text;
    // }

    
    // public List<GameObject> GetFormationSetting(string formation)
    // {
    //     List<GameObject> playersInFormation = new List<GameObject>();

    //     foreach(GameObject g in pp.pObjList)
    //     {
    //         PlayerObj pObj = g.GetComponent<PlayerObj>();
    //         if (pObj == null) continue;

    //         if (pObj.rostered == false) continue;
            
    //         if (pObj.p.formationSetting.ContainsKey(formation))
    //         {
    //             int s = pObj.p.formationSetting[formation];
    //             playersInFormation.Add(g);
    //         }
    //     }

    //     return playersInFormation;
    // }

    // public GameObject GetFirstSelectedPlayer()
    // {
    //     foreach(GameObject g in pp.pObjList)
    //     {
    //         PlayerObj pObj = g.GetComponent<PlayerObj>();
    //         if (pObj == null) continue;

    //         if (pObj.rostered == false) continue;
            
    //         if (pObj.selected)
    //         {
    //             return g;
    //         }
    //     }

    //     return null;
    // }

    // private void Recalc()
    // {
    //     //if (lineup != null) lineup.Recalc();
    //     if (roster != null) roster.Recalc();

    //     //if (lineup != null) totalPower = lineup.totalPower + roster.totalPower;

    //     UpdateText();
    // }

    // public void UpdateText()
    // {
    //     //update team name
    //     if (input_teamName != null) input_teamName.text = teamName;


    //     //update season text
    //     if (seasonObj != null) seasonObj.UpdateText();


    //     //$"Game: {gameNum}\n" +"Total = Lineup + Roll1 + Roll2 + Lineup\n" +
    //     gameText = "";
    //     gameText += $"Att: {simAtt}";
    //     if ((rollAtt0 != 0) && (rollAtt0 == rollAtt1))
    //     {
    //         gameText += $" *[{rollAtt0}] ";
    //     }

    //     gameText += $" - Mid: {simMid}";
    //     if ((rollMid0 != 0) && (rollMid0 == rollMid1))
    //     {
    //         gameText += $"*[{rollMid0}] ";
    //     }

    //     gameText += $" - Def: {simDef}";
    //     if ((rollDef0 != 0) && (rollDef0 == rollDef1))
    //     {
    //         gameText += $" *[{rollDef0}] ";
    //     }

    //     // if (text_teamStats != null) text_teamStats.text = $"Att: {lineup.att} - Mid: {lineup.mid} - Def: {lineup.def}" +
    //     //     $" - Total: {totalPower}\n" + 
    //     //     gameText;
    // }

    //Panel controller
    // public void HideAll()
    // {
    //     if (panel_home != null) panel_home.gameObject.SetActive(false);
    //     if (panel_lineup != null) panel_lineup.gameObject.SetActive(false);
    //     if (panel_playerpool != null) panel_playerpool.gameObject.SetActive(false);
    // }

    // public void ShowHome()
    // {
    //     HideAll();
    //     if (panel_home != null) panel_home.gameObject.SetActive(true);
    // }

    // public void ShowLineup()
    // {
    //     HideAll();
    //     panel_lineup.gameObject.SetActive(true);
    // }

    // public void ShowPlayerPool()
    // {
    //     HideAll();
    //     panel_playerpool.gameObject.SetActive(true);
    // }

    // public void ResetGame()
    // {
    //     gameNum = 0; 
    // }

    // public void PlayGame()
    // {
    //     Recalc();

    //     gameNum++;

    //     rollAtt0 = RollD6();
    //     rollAtt1 = RollD6();
        
    //     rollMid0 = RollD6();
    //     rollMid1 = RollD6();

    //     rollDef0 = RollD6();
    //     rollDef1 = RollD6();

    //     simAtt = rollAtt0 + rollAtt1 + lineup.att;
    //     simMid = rollMid0 + rollMid1 + lineup.mid;
    //     simDef = rollDef0 + rollDef1 + lineup.def;

    //     //if (rollAtt0 == rollAtt1) 
    //     //{
    //     //    gameText += $"*Injured Player: Att_{rollAtt0}\n";
    //     //}

    //     //if (rollMid0== rollMid1)
    //     //{
    //     //    gameText += $"*Injured Player: Mid_{rollMid0}\n";
    //     //}

    //     //if (rollDef0 == rollDef1)
    //     //{
    //     //    gameText += $"*Injured Player: Def_{rollDef0}\n";
    //     //}

    //     UpdateText();
    // }

    public int RollD6()
    {
        return Random.Range(1, 6);
    }
}

*/