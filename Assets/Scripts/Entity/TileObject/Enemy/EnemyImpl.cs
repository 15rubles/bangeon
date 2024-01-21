using UnityEngine;

namespace Entity.TileObject.Enemy
{
    [SelectionBase]
    public class EnemyImpl : MonoBehaviour, ITileObject
    {
        [SerializeField] protected float health;
        [SerializeField] protected float damage;
        public bool IsPassable()
        {
            return false;
        }
    }
}