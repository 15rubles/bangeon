using Component;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Tiles;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public enum EnemyAction
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

    public abstract class Enemy : MonoBehaviour
    {
        protected string enemyName;
        protected float health;
        protected EnemyAction _nextAction;
        [SerializeField] protected Tile currentTile;
        public abstract EnemyAction CalculateNextAction(List<Tile> tiles, Tile currentPlayerTile);
        public abstract void DoNextAction(List<Tile> tiles, Tile currentPlayerTile);

        public virtual void InitCurrentTile(List<Tile> tiles)
        {
            //TODO init currentTile пока что хардкод
        }
    }
}
