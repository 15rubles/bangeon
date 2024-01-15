using System.Collections.Generic;
using Tiles;
using UnityEngine;

namespace Assets.Scripts
{
    public enum TileObjectAction
    {
        Undefined,
        Attack,
        Stand,
        MoveFront,
        MoveBack,
        MoveLeft,
        MoveRight,
        Die
    }

    public abstract class TileObject : MonoBehaviour
    {
        protected string objectName;
        protected TileObjectAction _nextAction;
        [SerializeField] protected Tile currentTile;
        public abstract TileObjectAction CalculateNextAction(List<Tile> tiles, Tile currentPlayerTile);
        public abstract void DoNextAction(List<Tile> tiles, Tile currentPlayerTile);

        public virtual void InitCurrentTile(List<Tile> tiles)
        {
            //TODO init currentTile пока что хардкод
        }
    }
}
