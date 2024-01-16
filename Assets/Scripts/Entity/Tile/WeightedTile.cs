using System;

namespace Entity.Tile
{
    [Serializable]
    public class WeightedTile
    {
        private Tile tile;
        
        public Tile Tile => tile;
        public int G;
        public int H;
        public int F;
        public WeightedTile CameFrom;

        public WeightedTile(Tile tile, int g, int h, WeightedTile cameFrom)
        {
            this.tile = tile;
            G = g;
            H = h;
            F = g + h;
            CameFrom = cameFrom;
        }

        public WeightedTile(Tile tile)
        {
            this.tile = tile;
        }

        public void CalculateFCost()
        {
            F = G + H;
        }

    }
}