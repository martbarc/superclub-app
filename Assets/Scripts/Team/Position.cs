using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public int num = 0;
    public Player assignedPlayer;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AssignPlayer(Player player)
    {
        assignedPlayer = player;
    }

}
