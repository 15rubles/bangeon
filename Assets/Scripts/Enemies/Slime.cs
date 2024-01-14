using System;
using System.Collections.Generic;
using System.Linq;
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

        public override EnemyAction CalculateNextAction(List<Tile> tiles, Tile currentPlayerTile)
        {
            if (currentPlayerTile == currentTile)
            {
                _nextAction = EnemyAction.Attack;
            }
            else
            {
                List<Tile> neighborsTiles = currentTile.FindTileNeighbors();

                if (neighborsTiles.Count == 0)
                {
                    _nextAction = EnemyAction.Stand;
                }
                else
                {
                    Tile nextTile = neighborsTiles[Random.Range(0, neighborsTiles.Count)];
                    Direction nextTileDirection = currentTile.TileNeighborDirection(nextTile);
                    switch (nextTileDirection)
                    {
                        case Direction.Front:
                            _nextAction = EnemyAction.MoveFront;
                            break;
                        case Direction.Back:
                            _nextAction = EnemyAction.MoveBack;
                            break;
                        case Direction.Left:
                            _nextAction = EnemyAction.MoveLeft;
                            break;
                        case Direction.Right:
                            _nextAction = EnemyAction.MoveRight;
                            break;
                        default:
                            _nextAction = EnemyAction.Stand;
                            break;
                    }
                }
            }

            return _nextAction;
        }

        public override void DoNextAction(List<Tile> tiles, Tile currentPlayerTile)
        {
            if (_nextAction == EnemyAction.Undefined)
            {
                _nextAction = CalculateNextAction(tiles, currentPlayerTile);
            }

            Vector3 move = Vector3.zero;
            switch (_nextAction)
            {
                case EnemyAction.Stand:
                    break;
                case EnemyAction.MoveFront:
                    currentTile = currentTile.front;
                    move += new Vector3(0, 0, 2);
                    break;
                case EnemyAction.MoveBack:
                    currentTile = currentTile.back;
                    move += new Vector3(0, 0, -2);
                    break;
                case EnemyAction.MoveLeft:
                    currentTile = currentTile.left;
                    move += new Vector3(-2, 0, 0);
                    break;
                case EnemyAction.MoveRight:
                    currentTile = currentTile.right;
                    move += new Vector3(2, 0, 0);
                    break;
                case EnemyAction.Attack:
                    Debug.Log("Slime Attacked");
                    break;
            }

            transform.position += move; //TODO добавить анимации + и т д 
        }
    }
}