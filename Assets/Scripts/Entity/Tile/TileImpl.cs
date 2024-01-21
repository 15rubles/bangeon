using UnityEngine;

namespace Entity.Tile
{
    public class TileImpl : MonoBehaviour
    {
        [SerializeField] private TileData tileData;

        public TileData TileData => tileData;

        public TileImpl(TileData tileData)
        {
            this.tileData = tileData;
        }

        public bool IsPassable()
        {
            return tileData.IsPassable && tileData.TileObject.IsPassable();
        }
    }
}