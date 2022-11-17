using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap : MonoBehaviour
{
    public static GridMap Instance { private set; get; }
    private bool DEBUG = false;

    private Grid<GridNode> grid;
    public Grid<GridNode> GetGrid() { return this.grid; }

    private GridTileCollection tileCollection;

    private bool init = false;

    // ------ GRID SETTINGS ------
    //Ex. 475 = (480, 480):(middle of a 96x96)
    //          so (-5, -5):(middle tile size 10fx10f)
    private int gridX;
    private int gridY;
    private Vector3 gridOffset;

    private float cellSize;
    private Vector3 cellOffset;

    // Grid Vectors and tiles

    public static List<int[]> innerVertexes;
    public List<GridTile> tiles;

    // -------- Othersettings
    public static bool toBeReset = false;

    private bool gatespawned = false;
    private bool weaponspawned = false;

    public Vector3 playerSpawn;

    public int round;

    // --- FIRST LEVEL TUTORIAL

    [SerializeField] public GameObject tutObj;
    private GameObject tutObjObj;

    // CONST


    private void Awake()
    {
        Instance = this;
    }

    // ------ PUBLIC FUNCTIONS ------
    public int Init(int x, int y, float cellSize, GridTileCollection tileCollection, int newround, float enemies)
    {
        this.gridX = x;
        this.gridY = y;
        this.cellSize = cellSize;

        this.gridOffset = new Vector3(x * cellSize / 2.0f, y * cellSize / 2.0f);
        this.cellOffset = new Vector3(cellSize / 2.0f, cellSize / 2.0f);

        this.transform.position -= gridOffset; //move to offset location
        this.grid = new Grid<GridNode>(x, y, cellSize, this.transform.position, (Grid<GridNode> grid, int x, int y) => new GridNode(grid, x, y));

        this.tileCollection = tileCollection;
        if (this.tileCollection == null) { return -1; }       

        return 0;
    }

    public int AddTile(int id, int x, int y, out GridTile tile)
    {
        tile = null;
        if (id < -1) return -1; //null tile is -1

        GridNode gridNode = grid.GetGridObject(x, y);
        if (gridNode == null) return -1;

        Vector3 gridRealLocation = GetCellCenter(x, y);
        GameObject newGameObject = tileCollection.CreateTilePrefabFromID(id, gridRealLocation);
        if (newGameObject != null)
        {
            //gridNode.SetGameObject(newGameObject);
            gridNode.SetTile(newGameObject.GetComponent<GridTile>());

            tile = gridNode.GetTile();

           // if (DEBUG) Debug.Log("NOTE: GridMap[" + x + ", " + y + "] created at: " + gridNode.GetGameObject().transform.position.ToString());
        }

        if (newGameObject == null || tile == null)
        {
            Debug.Log("ERR: GridMap[" + x + ", " + y + "] failed to be created");
            return -1;
        }

        tiles.Add(tile);

        return 0;
    }

    public void GetMapSettings(out int x, out int y, out float size)
    {
        x = this.gridX;
        y = this.gridY;
        size = this.cellSize;
    }

    public Vector3 GetCellCenter(int x, int y)
    {
        float x_axis = (x * grid.GetCellSize() - cellOffset.x) + this.transform.position.x;
        float y_axis = (y * grid.GetCellSize() - cellOffset.y) + this.transform.position.y;
        return new Vector3(x_axis + 1.0f , y_axis + 1.0f); //may have to remove 1.0f
    }

    public bool isTriggerReset()
    {
        return toBeReset;
    }

    private List<int[]> GenerateInnerTileVertex()
    {
        innerVertexes = new List<int[]>();

        for (int x = 1; x < this.gridX - 1; x++)
        {
            for (int y = 1; y < this.gridY - 1; y++)
            {
                innerVertexes.Add(new int[2] { x, y });
            }
        }

        return innerVertexes;
    }
    
}
