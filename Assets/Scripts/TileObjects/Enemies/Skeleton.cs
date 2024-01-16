using Component;
using System.Collections.Generic;
using System.Linq;
using Tiles;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Skeleton : Enemy
    {
        [SerializeField] private List<WeightedTile> _pathTiles;

        private const double TOLERANCE = 0.1f;

        public override void InitCurrentTile(List<Tile> tiles)
        {
            //TODO init currentTile пока что хардкод
            currentTile = tiles
                .FirstOrDefault(lTile => Mathf.Abs(lTile.x - gameObject.transform.position.x) < TOLERANCE
                                         && Mathf.Abs(lTile.z - gameObject.transform.position.z) < TOLERANCE);
        }

        public override TileObjectAction CalculateNextAction(List<Tile> tiles, Tile currentPlayerTile)
        {
            _pathTiles = PathFinder.FindShortestPath(currentTile, currentPlayerTile);

            List<Tile> neighbours = currentTile.GetTileNeighbors();

            if (neighbours.Exists(x => x == currentPlayerTile))//TODO проверка на атаку
            {
                _nextAction = TileObjectAction.Attack;
            }
            else
            {
                switch (_pathTiles[0].Tile.TileNeighborDirection(_pathTiles[1].Tile))
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
            return _nextAction;
        }

        public override void DoNextAction(List<Tile> tiles, Tile currentPlayerTile)
        {
            base.DoNextAction(tiles, currentPlayerTile);
        }
    }
}
