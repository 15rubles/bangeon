using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tiles;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    private const double TOLERANCE = 0.1f;
    
    public List<Tile> tiles = new List<Tile>();
    [SerializeField] private int _xBound = 20, _zBound = 20;
    
    private void Awake()
    {
        Tile firstTile = new Tile(0, 0);
        tiles.Add(firstTile);
        addParrentTile(firstTile);
        Debug.Log(tiles.Count);
    }

    private void addParrentTile(Tile tile)
    {
        if (tile.front == null && tile.z + 2 <= _zBound )
        {
           Tile newTile = tiles
               .FirstOrDefault(lTile => Math.Abs(lTile.x - tile.x) < TOLERANCE && Math.Abs(lTile.z - tile.z - 2) < TOLERANCE);
           if (newTile == null)
           {
               newTile = new Tile(tile.x, tile.z + 2, null, null, tile, null);
               tiles.Add(newTile);
           } 
           tile.front = newTile;
           addParrentTile(newTile);
        }
        if (tile.back == null && tile.z - 2 >= 0)
        {
            Tile newTile = tiles
                .FirstOrDefault(lTile => Math.Abs(lTile.x - tile.x) < TOLERANCE && Math.Abs(lTile.z - tile.z + 2) < TOLERANCE);
            if (newTile == null)
            {
                newTile = new Tile(tile.x, tile.z - 2, null, null, null, tile );
                tiles.Add(newTile);
            } 
            tile.back = newTile;
            addParrentTile(newTile);
        }
        if (tile.left == null && tile.x - 2 >= 0)
        {
            Tile newTile = tiles
                .FirstOrDefault(lTile => Math.Abs(lTile.x - tile.x + 2) < TOLERANCE && Math.Abs(lTile.z - tile.z) < TOLERANCE);
            if (newTile == null)
            {
                newTile = new Tile(tile.x - 2, tile.z, null, tile, null, null);
                tiles.Add(newTile);
            } 
            tile.left = newTile;
            addParrentTile(newTile);
        }
        if (tile.right == null && tile.x + 2 <= _xBound)
        {
            Tile newTile = tiles
                .FirstOrDefault(lTile => Math.Abs(lTile.x - tile.x - 2) < TOLERANCE && Math.Abs(lTile.z - tile.z) < TOLERANCE);
            if (newTile == null)
            {
                newTile = new Tile(tile.x + 2, tile.z, tile, null, null, null );
                tiles.Add(newTile);
            } 
            tile.right = newTile;
            
            addParrentTile(newTile);
        }
    }

}

