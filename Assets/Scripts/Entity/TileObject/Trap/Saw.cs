using System;
using System.Collections.Generic;
using Common;

namespace Entity.TileObject.Trap
{
    public class Saw : Trap
    {
        // [SerializeField] private List<PathTile> _pathTiles;
        // [SerializeField] private PathTile currentTile2;
        //
        // private const double TOLERANCE = 0.1f;
        //
        // public override void InitCurrentTile(List<Tile> tiles)
        // {
        //     //TODO init currentTile пока что хардкод
        //     currentTile = tiles
        //         .FirstOrDefault(lTile => Math.Abs(lTile.x - gameObject.transform.position.x) < TOLERANCE
        //                                  && Math.Abs(lTile.z - gameObject.transform.position.z) < TOLERANCE);
        //
        //     currentTile2 = _pathTiles[0];
        //
        //     for (int i = 0; i < _pathTiles.Count - 1; i++)
        //     {
        //         _pathTiles[i].next = _pathTiles[i + 1];
        //     }
        //     _pathTiles[^1].next = _pathTiles[0];
        // }
        //
        // //public override TileObjectAction CalculateNextAction(List<Tile> tiles, Tile currentPlayerTile)
        // //{
        // //    deltaX = startTile.x - endTile.x;
        // //    deltaZ = startTile.z - endTile.z;
        //
        // //    if (currentTile == endTile)
        // //    {
        // //        (startTile, endTile) = (endTile, startTile);
        // //    }
        // //    else
        // //    {
        // //        if (deltaX == 0 || deltaZ == 0)
        // //        {
        // //            if (deltaX < 0)
        // //            {
        // //                _nextAction = TileObjectAction.MoveRight;
        // //            }
        // //            else if (deltaX > 0)
        // //            {
        // //                _nextAction = TileObjectAction.MoveLeft;
        // //            }
        //
        // //            if (deltaZ < 0)
        // //            {
        // //                _nextAction = TileObjectAction.MoveFront;
        // //            }
        // //            else if (deltaZ > 0)
        // //            {
        // //                _nextAction = TileObjectAction.MoveBack;
        // //            }
        // //        }
        // //        else
        // //        {
        // //            _nextAction = TileObjectAction.Stand;
        // //        }
        // //    }
        //
        // //    if (currentTile == currentPlayerTile)
        // //    {
        // //        _nextAction = TileObjectAction.Attack;
        // //    }
        //
        // //    return _nextAction;
        // //}
        //
        // public override TileObjectAction CalculateNextAction(List<Tile> tiles, Tile currentPlayerTile)
        // {
        //     switch (currentTile2.tile.TileNeighborDirection(currentTile2.next.tile))
        //     {
        //         case Direction.Front:
        //             nextAction = TileObjectAction.MoveFront;
        //             gameObject.transform.Rotate(0, 0, 0);
        //             break;
        //         case Direction.Back:
        //             nextAction = TileObjectAction.MoveBack;
        //             gameObject.transform.Rotate(0, 0, 0);
        //             break;
        //         case Direction.Left:
        //             nextAction = TileObjectAction.MoveLeft;
        //             gameObject.transform.Rotate(0, 90, 0);
        //             break;
        //         case Direction.Right:
        //             nextAction = TileObjectAction.MoveRight;
        //             gameObject.transform.Rotate(0, 90, 0);
        //             break;
        //         default:
        //             nextAction = TileObjectAction.Stand;
        //             break;
        //     }
        //     return nextAction;
        // }
        //
        // public override void DoNextAction(List<Tile> tiles, Tile currentPlayerTile)
        // {
        //     if (nextAction == TileObjectAction.Undefined)
        //     {
        //         nextAction = CalculateNextAction(tiles, currentPlayerTile);
        //     }
        //
        //     Vector3 move = Vector3.zero;
        //     switch (nextAction)
        //     {
        //         case TileObjectAction.Stand:
        //             break;
        //         case TileObjectAction.MoveFront:
        //             currentTile = currentTile.front;
        //             move += new Vector3(0, 0, 2);
        //             break;
        //         case TileObjectAction.MoveBack:
        //             currentTile = currentTile.back;
        //             move += new Vector3(0, 0, -2);
        //             break;
        //         case TileObjectAction.MoveLeft:
        //             currentTile = currentTile.left;
        //             move += new Vector3(-2, 0, 0);
        //             break;
        //         case TileObjectAction.MoveRight:
        //             currentTile = currentTile.right;
        //             move += new Vector3(2, 0, 0);
        //             break;
        //         case TileObjectAction.Attack:
        //             Debug.Log("Saw Attacked");
        //             break;
        //     }
        //
        //     transform.position += move;
        //
        //     currentTile2 = currentTile2.next;
        // }
        //
        // //public override void DoNextAction(List<Tile> tiles, Tile currentPlayerTile)
        // //{
        // //    if (_nextAction == TileObjectAction.Undefined)
        // //    {
        // //        _nextAction = CalculateNextAction(tiles, currentPlayerTile);
        // //    }
        //
        // //    Vector3 move = Vector3.zero;
        // //    switch (_nextAction)
        // //    {
        // //        case TileObjectAction.Stand:
        // //            break;
        // //        case TileObjectAction.MoveFront:
        // //            currentTile = currentTile.front;
        // //            move += new Vector3(0, 0, 2);
        // //            break;
        // //        case TileObjectAction.MoveBack:
        // //            currentTile = currentTile.back;
        // //            move += new Vector3(0, 0, -2);
        // //            break;
        // //        case TileObjectAction.MoveLeft:
        // //            currentTile = currentTile.left;
        // //            move += new Vector3(-2, 0, 0);
        // //            break;
        // //        case TileObjectAction.MoveRight:
        // //            currentTile = currentTile.right;
        // //            move += new Vector3(2, 0, 0);
        // //            break;
        // //        case TileObjectAction.Attack:
        // //            Debug.Log("Saw Attacked");
        // //            break;
        // //    }
        //
        // //    transform.position += move;
        // //}      
        public override TileObjectAction CalculateNextAction(List<Tile.TileImpl> tiles, Tile.TileImpl currentPlayerTileImpl)
        {
            throw new NotImplementedException();
        }
    }
}