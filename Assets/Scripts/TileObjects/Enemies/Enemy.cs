using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public abstract class Enemy : TileObject
    {
        [SerializeField] protected float health;
        [SerializeField] protected float damage;
    }
}
