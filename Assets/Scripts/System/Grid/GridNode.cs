using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridNode
{
    private Grid<GridNode> grid;
    private int x;
    private int y;

    private GridTile tile;
    //private GameObject obj; //Prefab

    public GridNode(Grid<GridNode> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;

        tile = null;
        //obj = null;
    }

    //public void SetGameObject(GameObject obj)
    //{
    //    this.obj = obj;
    //}

    //public GameObject GetGameObject()
    //{
    //    return obj;
    //}

    public void SetTile(GridTile tile)
    {
        this.tile = tile;
    }

    public GridTile GetTile()
    {
        return tile;
    }

    public void GetTile(out int x, out int y)
    {
        x = this.x;
        y = this.y;
    }
}

