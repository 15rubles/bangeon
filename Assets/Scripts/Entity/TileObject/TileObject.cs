using System.Collections.Generic;
using Common;
using UnityEngine;

namespace Entity.TileObject
{

    public abstract class TileObject : MonoBehaviour
    {
        [SerializeField] protected string objectName;
        protected TileObjectAction nextAction;
        [SerializeField] protected Tile.Tile currentTile;
        public abstract TileObjectAction CalculateNextAction(List<Tile.Tile> tiles, Tile.Tile currentPlayerTile);

        public virtual void DoNextAction(List<Tile.Tile> tiles, Tile.Tile currentPlayerTile)
        {
            if (nextAction == TileObjectAction.Undefined)
            {
                nextAction = CalculateNextAction(tiles, currentPlayerTile);
            }

            Vector3 move = Vector3.zero;
            switch (nextAction)
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
                    Debug.Log(objectName + " Attacked");
                    break;
            }

            transform.position += move;
        }

        public virtual void InitCurrentTile(List<Tile.Tile> tiles)
        {
            //TODO init currentTile пока что хардкод
        }
    }
}
