using UnityEngine;

namespace Tiles
{
    public class WeightedTile
    {
        public Tile tile;
        public int F;
        public int G;
        public int H;
        public Tile position;
        public Tile targetPosition;
        public Tile previousTile;//для поиска пути, мб куда-то перенести пока хз
        
        
        public WeightedTile(Tile start, Tile target, Tile previousTile, int g)
        {
            position = start;
            targetPosition = target;
            G = g;
            H = Mathf.Abs(start.x - target.x) + Mathf.Abs(start.z - target.z);
            F = G + H;
        }
    }
}