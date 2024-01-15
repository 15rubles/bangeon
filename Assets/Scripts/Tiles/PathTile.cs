using System;

namespace Tiles
{
    [Serializable]
    public class PathTile
    {
        public Tile tile;
        public PathTile next;
    }
}