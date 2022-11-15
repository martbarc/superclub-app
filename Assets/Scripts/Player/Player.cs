using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int power;

    private void Awake()
    {
        power = 0;
    }

    public int getPower()
    {
        return power;
    }
}
