using UnityEngine;

namespace Entity.TileObject.InteractiveObject
{
    [SelectionBase]
    public class Wall : MonoBehaviour, ITileObject
    {

        public bool IsPassable()
        {
            return false;
        }
    }
}