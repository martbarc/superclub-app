using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateClean;

public class GameController : MonoBehaviour
{
    [SerializeField] public CameraController camera_main;

    [SerializeField] public Team team;


    //UI
    [SerializeField] public CleanButton button_addPlayer;
    [SerializeField] public Popup popup_shop;
    public bool pshopShow = false;

    public int season_num;

    private void Awake()
    {
        season_num = 1;
        button_addPlayer.onClick.AddListener(ShowShop);
    }

    void Start()
    {
        HideShop();
    }

    public void HideShop()
    {
        popup_shop.gameObject.SetActive(false);
    }

    public void ShowShop()
    {
        popup_shop.gameObject.SetActive(true);
    }

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    
}
