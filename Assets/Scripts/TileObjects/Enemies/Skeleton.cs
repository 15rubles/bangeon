using System.Collections.Generic;
using System.Linq;
using Tiles;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Skeleton : Enemy
    {
        //[SerializeField] private PathFinder pathFinder;

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
            //List<Tile> path = pathFinder.FindPath(currentTile, currentPlayerTile);

            //Debug.Log(path.Count);

            if (true)
            {
                return TileObjectAction.MoveFront;
            }

        }

        public override void DoNextAction(List<Tile> tiles, Tile currentPlayerTile)
        {
            // if (CalculateNextAction() == EnemyAction.MoveFront)
            // {
            //     transform.position += new Vector3(0, 0, 2);
            // }
            // if (CalculateNextAction() == EnemyAction.MoveBack)
            // {
            //     transform.position += new Vector3(0, 0, -2);
            // }
            // if (CalculateNextAction() == EnemyAction.MoveLeft)
            // {
            //     transform.position += new Vector3(-2, 0, 0);
            // }
            // if (CalculateNextAction() == EnemyAction.MoveRight)
            // {
            //     transform.position += new Vector3(2, 0, 0);
            // }
            // if (CalculateNextAction() == EnemyAction.Stand)
            // {
            //     transform.position += Vector3.zero;
            // }
        }
    }
}
