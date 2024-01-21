using UnityEngine;

namespace Entity.TileObject.InteractiveObject
{
    [SelectionBase]
    public class Wall : MonoBehaviour, ITileObject
    {
        [SerializeField] private string name;
        public bool IsPassable()
        {
            return false;
        }
    }
}