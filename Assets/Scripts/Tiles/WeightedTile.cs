using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    [Serializable]
    public class WeightedTile
    {
        public Tile Tile;
        public int G;
        public int H;
        public int F;
        public WeightedTile CameFrom;

        public WeightedTile(Tile tile, int g, int h, WeightedTile cameFrom)
        {
            Tile = tile;
            G = g;
            H = h;
            F = g + h;
            CameFrom = cameFrom;
        }

        public WeightedTile(Tile tile)
        {
            Tile = tile;
        }

        public void CalculateFCost()
        {
            F = G + H;
        }

    }
}