using System;

namespace Entity.Tile
{
    [Serializable]
    public class WeightedTile
    {
        private TileImpl tileImpl;

        public TileImpl TileImpl => tileImpl;
        public int G;
        public int H;
        public int F;
        public WeightedTile CameFrom;

        public WeightedTile(TileImpl tileImpl, int g, int h, WeightedTile cameFrom)
        {
            this.tileImpl = tileImpl;
            G = g;
            H = h;
            F = g + h;
            CameFrom = cameFrom;
        }

        public WeightedTile(TileImpl tileImpl)
        {
            this.tileImpl = tileImpl;
        }

        public void CalculateFCost()
        {
            F = G + H;
        }

    }
}