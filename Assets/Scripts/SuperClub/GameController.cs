using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateClean;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] public CameraController camera_main;

    [SerializeField] public Team team;

    //UI
    [SerializeField] public CleanButton button_addPlayer;
    [SerializeField] public Popup popup_shop;
    [SerializeField] public CleanButton button_debug_addPlayer;

    [SerializeField] public CleanButton button_funds;
    [SerializeField] public TextMeshProUGUI text_teamFunds;
    [SerializeField] public CleanButton button_addFunds;

    [SerializeField] public CleanButton button_stats;
    [SerializeField] public Popup popup_stats;

    [SerializeField] public BonusSlider loophole_att;
    [SerializeField] public BonusSlider loophole_mid;
    [SerializeField] public BonusSlider loophole_def;

    [SerializeField] public TextMeshProUGUI text_totalstars;

    [SerializeField] public CleanButton button_bench;

    private void Awake()
    {
        button_addPlayer.onClick.AddListener(ShowShop);
        button_debug_addPlayer.onClick.AddListener(team.AddRandomPlayers);

        button_addFunds.onClick.AddListener(team.IncreaseFunds_1);

        button_stats.onClick.AddListener(ShowStats);

        button_bench.onClick.AddListener(team.lineup.SwitchLineupView);
    }

    void Start()
    {
        HideShop();
        HideStats();
    }

    public void HideShop()
    {
        popup_shop.gameObject.SetActive(false);
    }

    public void ShowShop()
    {
        popup_shop.gameObject.SetActive(true);
    }

    public void HideStats()
    {
        popup_stats.gameObject.SetActive(false);
    }

    public void ShowStats()
    {
        popup_stats.gameObject.SetActive(true);
    }

}
