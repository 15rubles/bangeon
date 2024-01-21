namespace Entity.TileObject.Enemy
{
    public class Slime : EnemyImpl
    {
        private const double TOLERANCE = 0.1f;

        // public override void InitCurrentTile(List<Tiles.Tile> tiles)
        // {
        //     // //TODO init currentTile пока что хардкод
        //     // currentTile = tiles
        //     //     .FirstOrDefault(lTile => Math.Abs(lTile.x - gameObject.transform.position.x) < TOLERANCE
        //     //                              && Math.Abs(lTile.z - gameObject.transform.position.z) < TOLERANCE);
        // }
        //
        // public override TileObjectAction CalculateNextAction(List<Tiles.Tile> tiles, Tiles.Tile currentPlayerTile)
        // {
        //     // if (currentPlayerTile == currentTile)
        //     // {
        //     //     nextAction = TileObjectAction.Attack;
        //     // }
        //     // else
        //     // {
        //     //     List<Tiles.Tile> neighborsTiles = currentTile.GetTileNeighbors();
        //     //
        //     //     if (neighborsTiles.Count == 0)
        //     //     {
        //     //         nextAction = TileObjectAction.Stand;
        //     //     }
        //     //     else
        //     //     {
        //     //         Tiles.Tile nextTile = neighborsTiles[Random.Range(0, neighborsTiles.Count)];
        //     //         Direction nextTileDirection = currentTile.TileNeighborDirection(nextTile);
        //     //         if (nextTile.isPassable)
        //     //         {
        //     //             switch (nextTileDirection)
        //     //             {
        //     //                 case Direction.Front:
        //     //                     nextAction = TileObjectAction.MoveFront;
        //     //                     break;
        //     //                 case Direction.Back:
        //     //                     nextAction = TileObjectAction.MoveBack;
        //     //                     break;
        //     //                 case Direction.Left:
        //     //                     nextAction = TileObjectAction.MoveLeft;
        //     //                     break;
        //     //                 case Direction.Right:
        //     //                     nextAction = TileObjectAction.MoveRight;
        //     //                     break;
        //     //                 default:
        //     //                     nextAction = TileObjectAction.Stand;
        //     //                     break;
        //     //             }
        //     //         }
        //     //         else
        //     //         {
        //     //             nextAction = TileObjectAction.Stand;
        //     //         }
        //     //     }
        //     // }
        //     // //TODO vizualization of next actions
        //     return nextAction;
        // }
        //
        // public override void DoNextAction(List<Tiles.Tile> tiles, Tiles.Tile currentPlayerTile)
        // {
        //     base.DoNextAction(tiles, currentPlayerTile);
        // }
    }
}