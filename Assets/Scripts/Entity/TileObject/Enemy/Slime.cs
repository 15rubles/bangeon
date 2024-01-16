using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Random = UnityEngine.Random;

namespace Entity.TileObject.Enemy
{
    public class Slime : Enemy
    {
        private const double TOLERANCE = 0.1f;

        public override void InitCurrentTile(List<Tile.Tile> tiles)
        {
            //TODO init currentTile пока что хардкод
            currentTile = tiles
                .FirstOrDefault(lTile => Math.Abs(lTile.x - gameObject.transform.position.x) < TOLERANCE
                                         && Math.Abs(lTile.z - gameObject.transform.position.z) < TOLERANCE);
        }

        public override TileObjectAction CalculateNextAction(List<Tile.Tile> tiles, Tile.Tile currentPlayerTile)
        {
            if (currentPlayerTile == currentTile)
            {
                nextAction = TileObjectAction.Attack;
            }
            else
            {
                List<Tile.Tile> neighborsTiles = currentTile.GetTileNeighbors();

                if (neighborsTiles.Count == 0)
                {
                    nextAction = TileObjectAction.Stand;
                }
                else
                {
                    Tile.Tile nextTile = neighborsTiles[Random.Range(0, neighborsTiles.Count)];
                    Direction nextTileDirection = currentTile.TileNeighborDirection(nextTile);
                    if (nextTile.isPassable)
                    {
                        switch (nextTileDirection)
                        {
                            case Direction.Front:
                                nextAction = TileObjectAction.MoveFront;
                                break;
                            case Direction.Back:
                                nextAction = TileObjectAction.MoveBack;
                                break;
                            case Direction.Left:
                                nextAction = TileObjectAction.MoveLeft;
                                break;
                            case Direction.Right:
                                nextAction = TileObjectAction.MoveRight;
                                break;
                            default:
                                nextAction = TileObjectAction.Stand;
                                break;
                        }
                    }
                    else
                    {
                        nextAction = TileObjectAction.Stand;
                    }
                }
            }
            //TODO vizualization of next actions
            return nextAction;
        }

        public override void DoNextAction(List<Tile.Tile> tiles, Tile.Tile currentPlayerTile)
        {
            base.DoNextAction(tiles, currentPlayerTile);
        }
    }
}