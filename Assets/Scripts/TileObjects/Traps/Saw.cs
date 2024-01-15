using System;
using System.Collections.Generic;
using UnityEngine;
using Tiles;
using System.Linq;
using Component;

namespace Assets.Scripts.TileObjects.Traps
{
    public class Saw : Trap
    {
        [SerializeField] private List<PathTile> _pathTiles; 
        [SerializeField] private PathTile currentTile2;
        
        [SerializeField] private Tile startTile;
        [SerializeField] private Tile endTile;
        [SerializeField] private int deltaX, deltaZ;

        private const double TOLERANCE = 0.1f;

        public override void InitCurrentTile(List<Tile> tiles)
        {
            //TODO init currentTile пока что хардкод
            currentTile = tiles
                .FirstOrDefault(lTile => Math.Abs(lTile.x - gameObject.transform.position.x) < TOLERANCE
                                         && Math.Abs(lTile.z - gameObject.transform.position.z) < TOLERANCE);

            currentTile2 = _pathTiles[0];
            for (int i = 0; i < _pathTiles.Count - 1; i++)
            {
                _pathTiles[i].next = _pathTiles[i + 1];
            }
            _pathTiles[^1].next = _pathTiles[0];
            
            startTile = tiles.Find(lTile => lTile.x == startTile.x && startTile.z == lTile.z);
            endTile = tiles.Find(lTile => lTile.x == endTile.x && endTile.z == lTile.z);
        }

        public override TileObjectAction CalculateNextAction(List<Tile> tiles, Tile currentPlayerTile)
        {
            deltaX = startTile.x - endTile.x;
            deltaZ = startTile.z - endTile.z;

            if (currentTile == endTile)
            {
                (startTile, endTile) = (endTile, startTile);
            }
            else
            {
                if (deltaX == 0 || deltaZ == 0)
                {
                    if (deltaX < 0)
                    {
                        _nextAction = TileObjectAction.MoveRight;
                    }
                    else if (deltaX > 0)
                    {
                        _nextAction = TileObjectAction.MoveLeft;
                    }

                    if (deltaZ < 0)
                    {
                        _nextAction = TileObjectAction.MoveFront;
                    }
                    else if (deltaZ > 0)
                    {
                        _nextAction = TileObjectAction.MoveBack;
                    }
                }
                else
                {
                    _nextAction = TileObjectAction.Stand;
                }
            }

            if (currentTile == currentPlayerTile)
            {
                _nextAction = TileObjectAction.Attack;
            }

            return _nextAction;
        }
        
        public TileObjectAction CalculateNextAction2(List<Tile> tiles, Tile currentPlayerTile)
        {
            switch (currentTile2.tile.TileNeighborDirection(currentTile2.next.tile))
            {
                case Direction.Front:
                    _nextAction = TileObjectAction.MoveFront;
                    break;
                case Direction.Back:
                    _nextAction = TileObjectAction.MoveBack;
                    break;
                case Direction.Left:
                    _nextAction = TileObjectAction.MoveLeft;
                    break;
                case Direction.Right:
                    _nextAction = TileObjectAction.MoveRight;
                    break;
                default:
                    _nextAction = TileObjectAction.Stand;
                    break;
            }
            return _nextAction;
        }
        
        public void DoNextAction2(List<Tile> tiles, Tile currentPlayerTile)
        {
            if (_nextAction == TileObjectAction.Undefined)
            {
                _nextAction = CalculateNextAction(tiles, currentPlayerTile);
            }

            Vector3 move = Vector3.zero;
            switch (_nextAction)
            {
                case TileObjectAction.Stand:
                    break;
                case TileObjectAction.MoveFront:
                    currentTile = currentTile.front;
                    move += new Vector3(0, 0, 2);
                    break;
                case TileObjectAction.MoveBack:
                    currentTile = currentTile.back;
                    move += new Vector3(0, 0, -2);
                    break;
                case TileObjectAction.MoveLeft:
                    currentTile = currentTile.left;
                    move += new Vector3(-2, 0, 0);
                    break;
                case TileObjectAction.MoveRight:
                    currentTile = currentTile.right;
                    move += new Vector3(2, 0, 0);
                    break;
                case TileObjectAction.Attack:
                    Debug.Log("Saw Attacked");
                    break;
            }

            transform.position += move;

            currentTile2 = currentTile2.next;
        }

        public override void DoNextAction(List<Tile> tiles, Tile currentPlayerTile)
        {
            if (_nextAction == TileObjectAction.Undefined)
            {
                _nextAction = CalculateNextAction(tiles, currentPlayerTile);
            }

            Vector3 move = Vector3.zero;
            switch (_nextAction)
            {
                case TileObjectAction.Stand:
                    break;
                case TileObjectAction.MoveFront:
                    currentTile = currentTile.front;
                    move += new Vector3(0, 0, 2);
                    break;
                case TileObjectAction.MoveBack:
                    currentTile = currentTile.back;
                    move += new Vector3(0, 0, -2);
                    break;
                case TileObjectAction.MoveLeft:
                    currentTile = currentTile.left;
                    move += new Vector3(-2, 0, 0);
                    break;
                case TileObjectAction.MoveRight:
                    currentTile = currentTile.right;
                    move += new Vector3(2, 0, 0);
                    break;
                case TileObjectAction.Attack:
                    Debug.Log("Saw Attacked");
                    break;
            }

            transform.position += move;
        }
        
      
    }
}
