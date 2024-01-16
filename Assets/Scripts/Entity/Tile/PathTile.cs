using System;

namespace Entity.Tile
{
    [Serializable]
    public class PathTile
    {
        public Tile tile;
        public PathTile next;
    }
}