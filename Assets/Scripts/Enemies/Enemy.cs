using Component;
using System;
using System.Diagnostics.Contracts;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public enum Actions
    {
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
        public string enemyName;
        public float health;
        public GameObject prefab;
        public GameObject player;
        public abstract Actions CalculateNextAction();
        public abstract void DoNextAction();
    }
}
