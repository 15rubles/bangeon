using System.Collections.Generic;
using System.Linq;
using Common;
using UnityEngine;

namespace Entity.TileObject.Trap
{
    public class Wall : Trap
    {
        private const double TOLERANCE = 0.1f;

        public override void InitCurrentTile(List<Tile.Tile> tiles)
        {
            //TODO init currentTile пока что хардкод
            currentTile = tiles
                .FirstOrDefault(lTile => Mathf.Abs(lTile.x - gameObject.transform.position.x) < TOLERANCE
                                         && Mathf.Abs(lTile.z - gameObject.transform.position.z) < TOLERANCE);

            tiles.FindAll(lTile => currentTile == lTile).ForEach(x => x.isPassable = false);
        }

        public override void DoNextAction(List<Tile.Tile> tiles, Tile.Tile currentPlayerTile)
        {
            base.DoNextAction(tiles, currentPlayerTile);
        }

        public override TileObjectAction CalculateNextAction(List<Tile.Tile> tiles, Tile.Tile currentPlayerTile)
        {
            nextAction = TileObjectAction.Stand;
            return nextAction;
        }
    }
}
