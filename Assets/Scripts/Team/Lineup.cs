using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lineup : MonoBehaviour
{
    [SerializeField] public List<Position> positions = new List<Position>(14);

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AssignPlayerToPosition(Player player, int positionIndex)
    {
        positions[positionIndex].AssignPlayer(player);
    }

    
}
