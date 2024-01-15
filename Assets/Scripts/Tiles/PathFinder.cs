using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Tiles
{
    public class PathFinder
    {
        private const int MoveCost = 1;

        public static List<WeightedTile> FindPath(Tile startTile, Tile finishTile)
        {
            WeightedTile start = new WeightedTile(startTile, MoveCost, CalculateDistance(startTile, finishTile),
                null);
            List<WeightedTile> openList = new List<WeightedTile> { start };
            List<WeightedTile> closedList = new List<WeightedTile>();

            return WeightNeighboursTiles(start, finishTile, openList, closedList);
        }

        private static List<WeightedTile> WeightNeighboursTiles(WeightedTile current, Tile finish,
            List<WeightedTile> openList, List<WeightedTile> closedList)
        {
            List<Tile> tiles = current.Tile.GetTileNeighbors();
            List<WeightedTile> neighboursTiles = new List<WeightedTile>();
            foreach (Tile tile in tiles)
            {
                neighboursTiles.Add(new WeightedTile(tile, current.G + MoveCost, CalculateDistance(finish, tile), current));
            }

            WeightedTile nextTile = neighboursTiles[0];
            foreach (WeightedTile weightedTile in neighboursTiles)
            {
                WeightedTile tileFromOpenList =
                    openList.FirstOrDefault(openListTile => openListTile.Tile == weightedTile.Tile);
                if (nextTile.F > weightedTile.F)
                {
                    nextTile = tileFromOpenList ?? weightedTile;
                }
                if (tileFromOpenList == null)
                {
                    openList.Add(weightedTile);
                } else if (tileFromOpenList.F > weightedTile.F)
                {
                    openList.Remove(tileFromOpenList);
                    openList.Add(weightedTile);
                }
            }
            closedList.Add(nextTile);

            if (nextTile.Tile == finish)
            {
                return closedList;
            }
            return WeightNeighboursTiles(nextTile, finish, openList, closedList);
        }

        private static int CalculateDistance(Tile a, Tile b)
        {
            int xDist = Mathf.Abs(a.x - b.x);
            int zDist = Mathf.Abs (a.z - b.z);
            int dist = (xDist + zDist) / 2; //TODO заменить 2 на скейл из конфига;
            return dist;
        }
    }
}
