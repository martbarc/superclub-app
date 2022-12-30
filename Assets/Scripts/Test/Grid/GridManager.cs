using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Test Class
 
public class GridManager : MonoBehaviour {
    [SerializeField] private int _width, _height;
 
    [SerializeField] private Tile _tilePrefab;
 
    private Dictionary<Vector2, Tile> _tiles;
    private int xoffset = 15;
    private int yoffset = 25;
 
    void Start() {
        GenerateGrid();
    }
 
    void GenerateGrid() {
        _tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                float xl = (x * xoffset) + this.transform.position.x;
                float yl = (y * yoffset) + this.transform.position.y;
                
                var spawnedTile = Instantiate(_tilePrefab, new Vector3(xl, yl), Quaternion.identity);
                spawnedTile.transform.SetParent(this.transform);
                spawnedTile.name = $"Tile_{x}_{y}";

                Debug.Log($"Tile spawned: {spawnedTile.name} at x:{xl} y:{yl}");
 
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
 
 
                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
    }
 
    public Tile GetTileAtPosition(Vector2 pos) {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}