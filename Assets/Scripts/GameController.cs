using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UltimateClean;

public class GameController : MonoBehaviour
{
    [SerializeField] public CameraController camera_main;

    [SerializeField] public Team team;


    //UI
    [SerializeField] public Popup popup_shop;
    public bool pshopShow = false;

    public int season_num;

    private void Awake()
    {
        season_num = 1;
    }

    void Start()
    {
        //ShowShop();
    }

    public void ShowShop()
    {
        if (pshopShow == false)
        {
            popup_shop.Open();
            pshopShow = true;
        }
        else
        {
            popup_shop.Close();
            pshopShow = false;
        }
        
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
