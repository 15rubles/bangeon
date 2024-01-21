using System.Collections.Generic;
using Common;

namespace Entity.TileObject.Trap
{
    public class SpikesStatic : Trap
    {
        // private const double TOLERANCE = 0.1f;
        //
        // public override void InitCurrentTile(List<Tiles.Tile> tiles)
        // {
        //     //TODO init currentTile пока что хардкод
        //     currentTile = tiles
        //         .FirstOrDefault(lTile => Mathf.Abs(lTile.x - gameObject.transform.position.x) < TOLERANCE
        //                                  && Mathf.Abs(lTile.z - gameObject.transform.position.z) < TOLERANCE);
        // }
        // public override TileObjectAction CalculateNextAction(List<Tiles.Tile> tiles, Tiles.Tile currentPlayerTile)
        // {
        //     nextAction = currentPlayerTile == currentTile ? TileObjectAction.Attack : TileObjectAction.Stand;
        //     return nextAction;
        // }
        //
        // public override void DoNextAction(List<Tiles.Tile> tiles, Tiles.Tile currentPlayerTile)
        // {
        //     //if (_nextAction == TileObjectAction.Undefined)
        //     //{
        //     //    _nextAction = CalculateNextAction(tiles, currentPlayerTile);
        //     //}
        //     //else
        //     //{
        //     //    switch(_nextAction)
        //     //    {
        //     //        case TileObjectAction.Attack: Debug.Log("SpikesStatic Attacked"); break; //TODO добавить нанесение урона
        //     //        case TileObjectAction.Stand: break;
        //     //    }
        //     //}
        //     base.DoNextAction(tiles, currentPlayerTile);
        // }
        public override TileObjectAction CalculateNextAction(List<Tile.TileImpl> tiles, Tile.TileImpl currentPlayerTileImpl)
        {
            throw new System.NotImplementedException();
        }
    }
}