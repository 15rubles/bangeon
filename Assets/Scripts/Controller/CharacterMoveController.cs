using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;

namespace Controller
{
    public class CharacterMoveController : MonoBehaviour
    {
        // [SerializeField] private GameController _gameController;
        // public Tile currentTile;
        // private List<Tile> _tiles;
        //
        // private void Start()
        // {
        //     _tiles = _gameController.tiles;
        //     currentTile = _tiles
        //         .FirstOrDefault(lTile => lTile.x == 0 && lTile.z == 0);
        //     _gameController.InitFirstEnemyAction(currentTile);
        // }
        //
        // private void Update()
        // {
        //     Vector3 move = Vector3.zero;
        //     if (Input.GetKeyDown(KeyCode.W))
        //         if (IsTargetTilePassable(Direction.Front))
        //             move += new Vector3(0, 0, 2);
        //     if (Input.GetKeyDown(KeyCode.A))
        //         if (IsTargetTilePassable(Direction.Left))
        //             move += new Vector3(-2, 0, 0);
        //     if (Input.GetKeyDown(KeyCode.S))
        //         if (IsTargetTilePassable(Direction.Back))
        //             move += new Vector3(0, 0, -2);
        //     if (Input.GetKeyDown(KeyCode.D))
        //         if (IsTargetTilePassable(Direction.Right))
        //             move += new Vector3(2, 0, 0);
        //     if (move != Vector3.zero)
        //     {
        //         gameObject.transform.position += move;
        //         _gameController.EndTurn(currentTile);
        //     }
        // }
        //
        // public bool IsTargetTilePassable(Direction direction)
        // {
        //     int x = currentTile.x, z = currentTile.z;
        //     switch (direction)
        //     {
        //         case Direction.Front:
        //             z += 2;
        //             break;
        //         case Direction.Back:
        //             z -= 2;
        //             break;
        //         case Direction.Left:
        //             x -= 2;
        //             break;
        //         case Direction.Right:
        //             x += 2;
        //             break;
        //     }
        //
        //     Tile tile = _tiles
        //         .FirstOrDefault(lTile => lTile.x == x && lTile.z == z);
        //
        //     if (tile == null) return false;
        //
        //     if (tile.isPassable)
        //     {
        //         currentTile = tile;
        //         return true;
        //     }
        //
        //     return false;
        // }
    }
}