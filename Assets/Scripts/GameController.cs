using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] public CameraController camera_main;
    [SerializeField] public Team myTeam;

    public int season_num;

    private void Awake()
    {
        
        myTeam = new Team();

        season_num = 1;

        camera_main.UpdateText_Stage("Draft Day!");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
