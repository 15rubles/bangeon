using System.Collections.Generic;
using Common;

namespace Entity.TileObject.Trap
{
    public class Wall : Trap
    {
        // private const double TOLERANCE = 0.1f;
        //
        // public override void InitCurrentTile(List<Tiles.Tile> tiles)
        // {
        //     //TODO init currentTile пока что хардкод
        //     currentTile = tiles
        //         .FirstOrDefault(lTile => Mathf.Abs(lTile.x - gameObject.transform.position.x) < TOLERANCE
        //                                  && Mathf.Abs(lTile.z - gameObject.transform.position.z) < TOLERANCE);
        //
        //     tiles.FindAll(lTile => currentTile == lTile).ForEach(x => x.isPassable = false);
        // }
        //
        // public override void DoNextAction(List<Tiles.Tile> tiles, Tiles.Tile currentPlayerTile)
        // {
        //     base.DoNextAction(tiles, currentPlayerTile);
        // }
        //
        // public override TileObjectAction CalculateNextAction(List<Tiles.Tile> tiles, Tiles.Tile currentPlayerTile)
        // {
        //     nextAction = TileObjectAction.Stand;
        //     return nextAction;
        // }
        public override TileObjectAction CalculateNextAction(List<Tile.TileImpl> tiles, Tile.TileImpl currentPlayerTileImpl)
        {
            throw new System.NotImplementedException();
        }
    }
}