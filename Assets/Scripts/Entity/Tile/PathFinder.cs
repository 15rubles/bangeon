using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entity.Tile
{
    public class PathFinder
    {
        private const int MoveCost = 1;

        public static List<WeightedTile> FindShortestPath(Tile startTile, Tile finishTile)
        {
            WeightedTile start = new WeightedTile(startTile, MoveCost, CalculateDistance(startTile, finishTile),
                null);
            List<WeightedTile> openList = new List<WeightedTile> { start };
            List<WeightedTile> closedList = new List<WeightedTile>();

            return LessWeightNeighboursTiles(start, finishTile, openList, closedList);
        }

        public static List<WeightedTile> FindLongestPath(Tile startTile, Tile finishTile)
        {
            WeightedTile start = new WeightedTile(startTile, MoveCost, CalculateDistance(startTile, finishTile),
                null);
            List<WeightedTile> openList = new List<WeightedTile> { start };
            List<WeightedTile> closedList = new List<WeightedTile>();

            return MostWeightNeighboursTiles(start, finishTile, openList, closedList);
        }

        private static List<WeightedTile> LessWeightNeighboursTiles(WeightedTile current, Tile finish,
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
            return LessWeightNeighboursTiles(nextTile, finish, openList, closedList);
        }

        private static List<WeightedTile> MostWeightNeighboursTiles(WeightedTile current, Tile finish,
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
                if (nextTile.F < weightedTile.F)
                {
                    nextTile = tileFromOpenList ?? weightedTile;
                }
                if (tileFromOpenList == null)
                {
                    openList.Add(weightedTile);
                }
                else if (tileFromOpenList.F < weightedTile.F)
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
            return MostWeightNeighboursTiles(nextTile, finish, openList, closedList);
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
