using UnityEngine;
using System.Collections.Generic;

namespace Tiles
{
    public class PathFinder
    {
        private const int MOVE_COST = 10;

        private List<WeightedTile> openList;
        private List<WeightedTile> closedList;

        //private List<WeightedTile> FindPath(int xStart, int yStart, int xEnd, int yEnd)
        //{
        //    //WeightedTile startTile = WeightedTile
        //    openList = new List<WeightedTile> { startTile };
        //    closedList = new List<WeightedTile>();


        //    startTile.gCost = 0;
        //    endTile.hCost = CalculateDistance(startTile, endTile);
        //    startTile.CalculateFCost();
        //}

        private int CalculateDistance(Tile a, Tile b)
        {
            int xDist = Mathf.Abs(a.x - b.x);
            int zDist = Mathf.Abs (a.z - b.z);
            int remaining = Mathf.Abs(xDist - zDist);

            return MOVE_COST * remaining;
        }
    }
}
