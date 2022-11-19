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

    private void Awake()
    {
        button_Update.onClick.AddListener(UpdateAll);
    }

    private void Start()
    {
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
}
