using UnityEngine;

namespace Entity.TileObject.Trap
{
    public abstract class Trap : TileObject
    {
        [SerializeField] protected int damage;
    }
}
