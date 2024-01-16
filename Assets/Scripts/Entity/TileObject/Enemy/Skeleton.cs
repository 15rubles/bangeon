using System.Collections.Generic;
using System.Linq;
using Common;
using Entity.Tile;
using UnityEngine;

namespace Entity.TileObject.Enemy
{
    public class Skeleton : Enemy
    {
        [SerializeField] private List<WeightedTile> _pathTiles;

        private const double TOLERANCE = 0.1f;

        public override void InitCurrentTile(List<Tile.Tile> tiles)
        {
            //TODO init currentTile пока что хардкод
            currentTile = tiles
                .FirstOrDefault(lTile => Mathf.Abs(lTile.x - gameObject.transform.position.x) < TOLERANCE
                                         && Mathf.Abs(lTile.z - gameObject.transform.position.z) < TOLERANCE);
        }

        public override TileObjectAction CalculateNextAction(List<Tile.Tile> tiles, Tile.Tile currentPlayerTile)
        {
            _pathTiles = PathFinder.FindShortestPath(currentTile, currentPlayerTile);

            List<Tile.Tile> neighbours = currentTile.GetTileNeighbors();

            if (neighbours.Exists(x => x == currentPlayerTile))//TODO проверка на атаку
            {
                nextAction = TileObjectAction.Attack;
            }
            else
            {
                switch (_pathTiles[0].Tile.TileNeighborDirection(_pathTiles[1].Tile))
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
            return nextAction;
        }

        public override void DoNextAction(List<Tile.Tile> tiles, Tile.Tile currentPlayerTile)
        {
            base.DoNextAction(tiles, currentPlayerTile);
        }
    }
}
