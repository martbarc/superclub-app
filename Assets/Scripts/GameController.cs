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
    [SerializeField] public CleanButton button_stats;
    [SerializeField] public CleanButton button_bench;
    [SerializeField] public Popup popup_shop;
    [SerializeField] public Popup popup_stats;

    public int season_num;

    private void Awake()
    {
        season_num = 1;
        button_addPlayer.onClick.AddListener(ShowShop);
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
