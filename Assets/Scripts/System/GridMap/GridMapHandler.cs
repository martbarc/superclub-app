using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapHandler : MonoBehaviour
{
    public static GridMapHandler Instance { private set; get; }
    private bool DEBUG = true;
    public bool IsDebug() { return this.DEBUG; }

    // ------ SETTINGS ------
    private bool init = false;
    public bool IsInit() { return init; }

    // ------ PUBLIC PROPERTIES ------
    [SerializeField] public GameObject gridMap;
    [SerializeField] public GridTileCollection gridTileCollection;

    private GridMapHandlerProperties PROP;
    public GridMapHandlerProperties GetGridProperties() { return PROP; }

    public GridMap map;
    public GridTileCollection tiles;

    private GameObject mapObj;
    //public GridMap GetMap() { return this.map; }

    [SerializeField] public GameObject openingObj;
    private GameObject opOb;

    // ------ MonoBehavior Functions ------
    private void Awake()
    {
        Instance = this;
        InitTiles();
        PROP = new GridMapHandlerProperties();
    }

    public int InitTiles()
    {
        tiles = (GridTileCollection)Instantiate(gridTileCollection, this.transform.position, Quaternion.identity);
        if (tiles!=null)
        {
            tiles.transform.parent = this.transform;
            return 0;
        }
        return -1;
    }

    public int InitMap(int round, float enemies)
    {
        this.mapObj = Instantiate(gridMap, this.transform.position, Quaternion.identity);
        this.map = mapObj.GetComponent<GridMap>();

        if (map != null)
        {
            int mod = (round / 3);
            int status = map.Init(PROP.GRIDSIZE_X + (3 * mod), PROP.GRIDSIZE_Y +  (2 * mod), PROP.GetCellSize(), tiles, round, enemies);
            if (status == 0)
            {
                map.transform.parent = this.transform;
            }
            return status;
        }

        return -1;
    }

    public int ReInitMap(int round, float enemies)
    {
        Destroy(mapObj);
        InitMap(round, enemies);

        return 0;
    }

}
