using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Team : MonoBehaviour
{
    [SerializeField] public Lineup lineup;
    [SerializeField] public Roster roster;

    [SerializeField] public TextMeshProUGUI text_teamStats;
    [SerializeField] public Button button_Update;

    //Panels
    [SerializeField] public GameObject panel_roster;
    [SerializeField] public GameObject panel_lineup;
    [SerializeField] public GameObject panel_season;

    [SerializeField] public Button button_roster;
    [SerializeField] public Button button_lineup;
    [SerializeField] public Button button_season;

    private void Awake()
    {
        button_Update.onClick.AddListener(UpdateAll);

        button_roster.onClick.AddListener(ShowRoster);
        button_lineup.onClick.AddListener(ShowLineup);
        button_season.onClick.AddListener(ShowSeason);
    }

    private void Start()
    {
        ShowRoster();

        UpdateTeamStatsText();
    }

    private void UpdateAll()
    {
        lineup.Recalc();

        UpdateTeamStatsText();
    }

    public void UpdateTeamStatsText()
    {
        text_teamStats.text = $"Att: {lineup.att} - Mid: {lineup.mid} - Def: {lineup.def}\nTotal: {roster.totalPower}";
    }

    //Panel controller
    public void HideAll()
    {
        panel_roster.gameObject.SetActive(false);
        panel_lineup.gameObject.SetActive(false);
        panel_season.gameObject.SetActive(false);
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
}
