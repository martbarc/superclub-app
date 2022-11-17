using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    public static GridHandler Instance { private set; get; }
    private bool DEBUG = true;
    public bool IsDebug() { return this.DEBUG; }

    // ------ UI OBJECTS ------
    private Camera mainCamera;

    // ------ SETTINGS ------
    private bool init = false;
    public bool IsInit() { return init; }

    // ------ PUBLIC PROPERTIES ------
    [SerializeField] public GridObject gridObject;
    [SerializeField] public GridTileCollection gridTileCollection;

    private GridHandlerProperties PROP;
    public GridHandlerProperties GetGridProperties() { return PROP; }

    private GridObject grid;
    private GridTileCollection tiles;
    public GridObject GetTileGrid() { return this.grid; }

    // ------ MonoBehavior Functions ------
    private void Awake()
    {
        Instance = this;
    }

    public int Init()
    {
        grid = (GridObject)Instantiate(gridObject, this.transform.position, Quaternion.identity);
        tiles = (GridTileCollection)Instantiate(gridTileCollection, this.transform.position, Quaternion.identity);
        if (grid != null && tiles != null)
        {
            PROP = new GridHandlerProperties();
            int status = grid.Init(PROP.GRIDSIZE_X, PROP.GRIDSIZE_Y, PROP.GetCellSize(), tiles);
            if (status == 0)
            {
                grid.transform.parent = this.transform;
                tiles.transform.parent = this.transform;
            }
            return status;
        }

        return -1;
    }
}
