using UnityEngine;

namespace Tiles
{
    public class WeightedTile
    {
        public Tile tile;
        public int gCost;
        public int hCost;
        public int fCost;
        public WeightedTile cameFrom;

        public WeightedTile(Tile tile, int g, int f, int h)
        {
            this.hCost = h;
            this.gCost = g;
            this.fCost = f;
            this.tile = tile;
        }

        public WeightedTile(Tile tile) { this.tile = tile; }

        public void CalculateFCost()
        {
            fCost = gCost + hCost;
        }

    }
}