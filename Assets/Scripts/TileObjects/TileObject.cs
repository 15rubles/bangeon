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

        public virtual void DoNextAction(List<Tile> tiles, Tile currentPlayerTile)
        {
            if (_nextAction == TileObjectAction.Undefined)
            {
                _nextAction = CalculateNextAction(tiles, currentPlayerTile);
            }

            Vector3 move = Vector3.zero;
            switch (_nextAction)
            {
                case TileObjectAction.Stand:
                    break;
                case TileObjectAction.MoveFront:
                    currentTile = currentTile.front;
                    move += new Vector3(0, 0, 2);
                    break;
                case TileObjectAction.MoveBack:
                    currentTile = currentTile.back;
                    move += new Vector3(0, 0, -2);
                    break;
                case TileObjectAction.MoveLeft:
                    currentTile = currentTile.left;
                    move += new Vector3(-2, 0, 0);
                    break;
                case TileObjectAction.MoveRight:
                    currentTile = currentTile.right;
                    move += new Vector3(2, 0, 0);
                    break;
                case TileObjectAction.Attack:
                    Debug.Log("Saw Attacked");
                    break;
            }

            transform.position += move;
        }

        public virtual void InitCurrentTile(List<Tile> tiles)
        {
            //TODO init currentTile пока что хардкод
        }
    }
}
