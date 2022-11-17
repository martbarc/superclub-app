using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTileCollection : MonoBehaviour
{
    //
    [SerializeField] public List<GameObject> tileCollection;

    public GameObject CreateTilePrefabFromID(int id, Vector3 location)
    {
        // can change to binary search
        foreach (GameObject obj in tileCollection)
        {
            GridTile tile = obj.GetComponent<GridTile>();
            if (tile != null)
            {
                if (tile.id == id)
                {
                    return CreateTile(obj, location);
                }
            }
        }

        return null;
    }

    public GameObject CreateTilePrefabFromName(string tileName, Vector3 location)
    {
        foreach (GameObject obj in tileCollection)
        {
            GridTile tile = obj.GetComponent<GridTile>();
            if (tile != null)
            {
                if (tile.tileName == tileName)
                {
                    return CreateTile(obj, location);
                }
            }
        }

        return null;
    }

    public GridTile GetTile(int index)
    {
        if (index >= 0 && index < tileCollection.Count)
        {
            GridTile tile = tileCollection[index].GetComponent<GridTile>();
            if (tile != null)
            {
                return tile;
            }
        }
        return null;
    }


    // ------ PRIVATE ------
    private GameObject CreateTile(GameObject tile, Vector3 location)
    {
        GameObject obj = Instantiate(tile, location, Quaternion.identity);

        return obj;
    }
}
