using System;
using UnityEngine.Serialization;

namespace Entity.Tile
{
    [Serializable]
    public class PathTile
    {
        [FormerlySerializedAs("tile")] public TileImpl tileImpl;
        public PathTile next;
    }
}