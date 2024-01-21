using System.Collections.Generic;
using Entity.Tile;
using UnityEngine;

namespace Entity.TileObject.Enemy
{
    public class Shy : EnemyImpl
    {
        private const double TOLERANCE = 0.1f;
        [SerializeField] private List<WeightedTile> _pathTiles;

        public void InitCurrentTile(List<TileImpl> tiles)
        {
            // //TODO init currentTile пока что хардкод
            // currentTile = tiles
            //     .FirstOrDefault(lTile => Math.Abs(lTile.x - gameObject.transform.position.x) < TOLERANCE
            //                              && Math.Abs(lTile.z - gameObject.transform.position.z) < TOLERANCE);
        }

        // public TileObjectAction CalculateNextAction(List<Tile> tiles, Tile currentPlayerTile)
        // {
        //     // _pathTiles = PathFinderTools.FindLongestPath(currentTile, currentPlayerTile);
        //     //
        //     // List<Tile> neighborTiles = currentTile.GetTileNeighbors();
        //     //
        //     // _pathTiles[0].Tile.TileNeighborDirection(_pathTiles[1].Tile);
        //
        //
        //
        //     //if(_pathTiles[0].Tile.TileNeighborDirection(_pathTiles[1].Tile) == Direction.Back)
        //     //{
        //     //    if(neighborTiles.Exists(x => x.isPassable == true))
        //     //    {
        //     //        if (currentTile.left.isPassable && currentTile.left != null)
        //     //        {
        //     //            _nextAction = TileObjectAction.MoveLeft;
        //     //        }
        //     //        if (currentTile.right.isPassable && currentTile.right != null)
        //     //        {
        //     //            _nextAction = TileObjectAction.MoveRight;
        //     //        }
        //     //        if (currentTile.front.isPassable && currentTile.front != null)
        //     //        {
        //     //            _nextAction = TileObjectAction.MoveFront;
        //     //        }
        //     //    }
        //     //}
        //     //if (_pathTiles[0].Tile.TileNeighborDirection(_pathTiles[1].Tile) == Direction.Front)
        //     //{
        //     //    if (neighborTiles.Exists(x => x.isPassable == true))
        //     //    {
        //     //        if (currentTile.left.isPassable && currentTile.left != null)
        //     //        {
        //     //            _nextAction = TileObjectAction.MoveLeft;
        //     //        }
        //     //        if (currentTile.right.isPassable && currentTile.right != null)
        //     //        {
        //     //            _nextAction = TileObjectAction.MoveRight;
        //     //        }
        //     //        if (currentTile.back.isPassable && currentTile.back != null)
        //     //        {
        //     //            _nextAction = TileObjectAction.MoveBack;
        //     //        }
        //     //    }
        //     //}
        //     //if (_pathTiles[0].Tile.TileNeighborDirection(_pathTiles[1].Tile) == Direction.Right)
        //     //{
        //     //    if (neighborTiles.Exists(x => x.isPassable == true))
        //     //    {
        //     //        if (currentTile.left.isPassable && currentTile.left != null)
        //     //        {
        //     //            _nextAction = TileObjectAction.MoveLeft;
        //     //        }
        //     //        if (currentTile.back.isPassable && currentTile.back != null)
        //     //        {
        //     //            _nextAction = TileObjectAction.MoveBack;
        //     //        }
        //     //        if (currentTile.front.isPassable && currentTile.front != null)
        //     //        {
        //     //            _nextAction = TileObjectAction.MoveFront;
        //     //        }
        //     //    }
        //     //}
        //     //if (_pathTiles[0].Tile.TileNeighborDirection(_pathTiles[1].Tile) == Direction.Left)
        //     //{
        //     //    if (neighborTiles.Exists(x => x.isPassable == true))
        //     //    {
        //     //        if (currentTile.back.isPassable && currentTile.back != null)
        //     //        {
        //     //            _nextAction = TileObjectAction.MoveBack;
        //     //        }
        //     //        if (currentTile.right.isPassable && currentTile.right != null)
        //     //        {
        //     //            _nextAction = TileObjectAction.MoveRight;
        //     //        }
        //     //        if (currentTile.front.isPassable && currentTile.front != null)
        //     //        {
        //     //            _nextAction = TileObjectAction.MoveFront;
        //     //        }
        //     //    }
        //     //}
        //     //TODO подумать как можно уменьшить
        //     return nextAction;
        // }


        // public override void DoNextAction(List<Tile> tiles, Tile currentPlayerTile)
        // {
        //     base.DoNextAction(tiles, currentPlayerTile);
        // }
    }
}