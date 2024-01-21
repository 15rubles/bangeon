using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;


namespace Controller
{
    public class GameController : MonoBehaviour
    {
        // private const double TOLERANCE = 0.1f;
        //
        // private int turnCounter = 1;
        //
        // [SerializeField] private List<Enemy> enemies;
        //
        // [SerializeField] private List<Trap> traps;
        //
        // //[SerializeField] private List<InteractiveObject> _interactiveObjects;
        // [SerializeField] private TMP_Text turnText;
        //
        // public List<Tile> tiles = new List<Tile>();
        // [SerializeField] private int xBound = 20;
        // [SerializeField] private int zBound = 20;
        //
        // private List<TileObject> tileObjects;
        //
        // private void Awake()
        // {
        //     Tile firstTile = new Tile(0, 0, true);
        //     tiles.Add(firstTile);
        //     AddParentTile(firstTile);
        //     //_tileObjects.Union(_enemies).Union(_traps);
        // }
        //
        // public void InitFirstEnemyAction(Tile currentPlayerTile)
        // {
        //     foreach (Enemy enemy in enemies)
        //     {
        //         enemy.InitCurrentTile(tiles); //TODO init currentTile пока что хардкод
        //         enemy.CalculateNextAction(tiles, currentPlayerTile);
        //         //TODO vizualization of next actions
        //     }
        //
        //     foreach (Trap trap in traps)
        //     {
        //         trap.InitCurrentTile(tiles); //TODO init currentTile пока что хардкод
        //         trap.CalculateNextAction(tiles, currentPlayerTile);
        //         //TODO vizualization of next actions
        //     }
        //
        //     //foreach(TileObject tileObject in _tileObjects)
        //     //{
        //     //    tileObject.InitCurrentTile(tiles);//TODO init currentTile пока что хардкод
        //     //    tileObject.CalculateNextAction(tiles, currentPlayerTile);
        //     //    //TODO vizualization of next actions
        //     //}
        // }
        //
        // private void AddParentTile(Tile tile)
        // {
        //     if (tile.front == null && tile.z + 2 <= zBound)
        //     {
        //         Tile newTile = tiles
        //             .FirstOrDefault(lTile => lTile.x == tile.x && lTile.z == tile.z - 2);
        //         if (newTile == null)
        //         {
        //             newTile = new Tile(tile.x, tile.z + 2, null, null, tile, null, true);
        //             tiles.Add(newTile);
        //         }
        //
        //         tile.front = newTile;
        //         AddParentTile(newTile);
        //     }
        //
        //     if (tile.back == null && tile.z - 2 >= 0)
        //     {
        //         Tile newTile = tiles
        //             .FirstOrDefault(lTile =>
        //                 Math.Abs(lTile.x - tile.x) < TOLERANCE && Math.Abs(lTile.z - tile.z + 2) < TOLERANCE);
        //         if (newTile == null)
        //         {
        //             newTile = new Tile(tile.x, tile.z - 2, null, null, null, tile, true);
        //             tiles.Add(newTile);
        //         }
        //
        //         tile.back = newTile;
        //         AddParentTile(newTile);
        //     }
        //
        //     if (tile.left == null && tile.x - 2 >= 0)
        //     {
        //         Tile newTile = tiles
        //             .FirstOrDefault(lTile =>
        //                 Math.Abs(lTile.x - tile.x + 2) < TOLERANCE && Math.Abs(lTile.z - tile.z) < TOLERANCE);
        //         if (newTile == null)
        //         {
        //             newTile = new Tile(tile.x - 2, tile.z, null, tile, null, null, true);
        //             tiles.Add(newTile);
        //         }
        //
        //         tile.left = newTile;
        //         AddParentTile(newTile);
        //     }
        //
        //     if (tile.right == null && tile.x + 2 <= xBound)
        //     {
        //         Tile newTile = tiles
        //             .FirstOrDefault(lTile =>
        //                 Math.Abs(lTile.x - tile.x - 2) < TOLERANCE && Math.Abs(lTile.z - tile.z) < TOLERANCE);
        //         if (newTile == null)
        //         {
        //             newTile = new Tile(tile.x + 2, tile.z, tile, null, null, null, true);
        //             tiles.Add(newTile);
        //         }
        //
        //         tile.right = newTile;
        //
        //         AddParentTile(newTile);
        //     }
        // }
        //
        //
        // public void EndTurn(Tile currentPlayerTile)
        // {
        //     turnCounter++;
        //     turnText.text = turnCounter.ToString();
        //     foreach (Enemy enemy in enemies)
        //     {
        //         enemy.DoNextAction(tiles, currentPlayerTile);
        //     }
        //
        //     foreach (Enemy enemy in enemies)
        //     {
        //         enemy.CalculateNextAction(tiles, currentPlayerTile);
        //     }
        //
        //     foreach (Trap trap in traps)
        //     {
        //         trap.CalculateNextAction(tiles, currentPlayerTile);
        //     }
        //
        //     foreach (Trap trap in traps)
        //     {
        //         trap.DoNextAction(tiles, currentPlayerTile);
        //     }
        //
        //     //foreach(TileObject tileObject in _tileObjects)
        //     //{
        //     //    tileObject.DoNextAction(tiles, currentPlayerTile);
        //     //}
        //     //foreach (TileObject tileObject in _tileObjects)
        //     //{
        //     //    tileObject.CalculateNextAction(tiles, currentPlayerTile);
        //     //}
        // }
    }
}