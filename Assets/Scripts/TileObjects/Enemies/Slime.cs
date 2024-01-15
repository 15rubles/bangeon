using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.Enemies;
using Component;
using Tiles;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemies
{
    public class Slime : Enemy
    {
        private const double TOLERANCE = 0.1f;

        public override void InitCurrentTile(List<Tile> tiles)
        {
            //TODO init currentTile пока что хардкод
            currentTile = tiles
                .FirstOrDefault(lTile => Math.Abs(lTile.x - gameObject.transform.position.x) < TOLERANCE
                                         && Math.Abs(lTile.z - gameObject.transform.position.z) < TOLERANCE);
        }

        public override TileObjectAction CalculateNextAction(List<Tile> tiles, Tile currentPlayerTile)
        {
            if (currentPlayerTile == currentTile)
            {
                _nextAction = TileObjectAction.Attack;
            }
            else
            {
                List<Tile> neighborsTiles = currentTile.FindTileNeighbors();

                if (neighborsTiles.Count == 0)
                {
                    _nextAction = TileObjectAction.Stand;
                }
                else
                {
                    Tile nextTile = neighborsTiles[Random.Range(0, neighborsTiles.Count)];
                    Direction nextTileDirection = currentTile.TileNeighborDirection(nextTile);
                    switch (nextTileDirection)
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
                }
            }
            //TODO vizualization of next actions
            return _nextAction;
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
                    Debug.Log("Slime Attacked");
                    break;
            }

            transform.position += move; //TODO добавить анимации + и т д 
        }
    }
}