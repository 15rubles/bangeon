using UnityEngine;

namespace Entity.TileObject.Enemy
{
    public abstract class Enemy : TileObject
    {
        [SerializeField] protected float health;
        [SerializeField] protected float damage;
    }
}
