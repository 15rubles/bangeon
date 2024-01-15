using System.Collections.Generic;
using System.Linq;
using Tiles;
using UnityEngine;
using System;

namespace Assets.Scripts.Enemies
{
    public class Shy : Enemy
    {
        private const double TOLERANCE = 0.1f;
        [SerializeField] private List<WeightedTile> _pathTiles;

        public override void InitCurrentTile(List<Tile> tiles)
        {
            //TODO init currentTile пока что хардкод
            currentTile = tiles
                .FirstOrDefault(lTile => Math.Abs(lTile.x - gameObject.transform.position.x) < TOLERANCE
                                         && Math.Abs(lTile.z - gameObject.transform.position.z) < TOLERANCE);
        }

        public override TileObjectAction CalculateNextAction(List<Tile> tiles, Tile currentPlayerTile)
        {
            _pathTiles = PathFinder.FindPath(currentTile, currentPlayerTile);
            
            List<Tile> neighborTiles = currentTile.GetTileNeighbors();

            if (neighborTiles.Count == 0)
            {
                _nextAction = TileObjectAction.Stand;
            }
            else
            {
                if(neighborTiles.Count < 4)
                {
                    if(currentTile.right == null || currentTile.left == null)
                    {
                        switch (UnityEngine.Random.Range(0, 2))
                        {
                            case 0: _nextAction = TileObjectAction.MoveFront; break;
                            case 1: _nextAction = TileObjectAction.MoveBack; break;
                        }
                    }
                    if(currentTile.back == null || currentTile.front == null)
                    {
                        switch (UnityEngine.Random.Range(0, 2))
                        {
                            case 0: _nextAction = TileObjectAction.MoveLeft; break;
                            case 1: _nextAction = TileObjectAction.MoveRight; break;
                        }
                    }
                }
                else
                {
                    if (currentPlayerTile == currentTile.left)
                    {
                        _nextAction = TileObjectAction.MoveRight;
                        Debug.Log(currentPlayerTile == currentTile.left);
                    }
                    if (currentPlayerTile == currentTile.right)
                    {
                        _nextAction = TileObjectAction.MoveLeft;
                    }
                    if (currentPlayerTile == currentTile.back)
                    {
                        _nextAction = TileObjectAction.MoveFront;
                    }
                    if (currentPlayerTile == currentTile.front)
                    {
                        _nextAction = TileObjectAction.MoveBack;
                    }
                }
            }

            return _nextAction;

            //TODO адекватное поведение прикола на границе карты
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
                    _nextAction = TileObjectAction.Stand;
                    break;
                case TileObjectAction.MoveBack:
                    currentTile = currentTile.back;
                    move += new Vector3(0, 0, -2);
                    _nextAction = TileObjectAction.Stand;
                    break;
                case TileObjectAction.MoveLeft:
                    currentTile = currentTile.left;
                    move += new Vector3(-2, 0, 0);
                    _nextAction = TileObjectAction.Stand;
                    break;
                case TileObjectAction.MoveRight:
                    currentTile = currentTile.right;
                    move += new Vector3(2, 0, 0);
                    _nextAction = TileObjectAction.Stand;
                    //TODO нормально придумать проверку
                    break;
            }

            transform.position += move;
        }
    }
}
