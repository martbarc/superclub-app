using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains the properties of a grid
/// </summary>
public class GridMapHandlerProperties : MonoBehaviour
{
    // STATIC
    private static float CELLSIZE = 2.0f;
    public float GetCellSize() { return CELLSIZE; }

    private static float DEFAULT_ANGLE = 0.0f;//90.0f;
    public float GetDefaultAngle() { return DEFAULT_ANGLE; }


    //DYNAMIC REACTIVE (TO DYNAMIC CORE)
    public int GRIDSIZE_X = 9; // depends on CLASS (default = 24)
    public int GRIDSIZE_Y = 6; // depends on CLASS (default = 24)

    public GridMapHandlerProperties()
    {

    }
}
