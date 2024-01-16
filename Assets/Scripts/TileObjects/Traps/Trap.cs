using UnityEngine;

namespace Assets.Scripts.TileObjects.Traps
{
    public abstract class Trap : TileObject
    {
        [SerializeField] protected int damage;
    }
}
