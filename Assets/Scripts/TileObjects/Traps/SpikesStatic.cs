using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using Assets.Scripts.TileObjects.Traps;
using Tiles;
using UnityEngine;

namespace TileObjects.Traps
{
    public class SpikesStatic : Trap
    {
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
            _nextAction = currentPlayerTile == currentTile ? TileObjectAction.Attack : TileObjectAction.Stand;
            return _nextAction;
        }

        public override void DoNextAction(List<Tile> tiles, Tile currentPlayerTile)
        {
            if (_nextAction == TileObjectAction.Undefined)
            {
                _nextAction = CalculateNextAction(tiles, currentPlayerTile);
            }
            else
            {
                switch(_nextAction)
                {
                    case TileObjectAction.Attack: Debug.Log("SpikesStatic Attacked"); break; //TODO добавить нанесение урона
                    case TileObjectAction.Stand: break;
                }
            }
        }
    }
}
