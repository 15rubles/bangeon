using UnityEngine;
using System.Collections.Generic;
using System;
using Unity.VisualScripting;

namespace Tiles
{
    [Serializable]
    public class PathFinder : MonoBehaviour
    {
        public List<Tile> RetracePath(Tile start, Tile target)
        {
            List<Tile> path = new List<Tile>();
            Tile current = target;

            while (current != start)
            {
                path.Add(current);
                current = current.previousTile;
            }

            path.Reverse();
            return path;
        }

        public int GetDistance(Tile start, Tile target)
        {
            int distX = Mathf.Abs(start.x - target.x);
            int distZ = Mathf.Abs(start.z - target.z);

            return distX + distZ;
        }

        public List<Tile> FindPath(Tile start, Tile target)
        {
            List<Tile> path = new List<Tile>();

            List<Tile> openTiles = new List<Tile>();
            List<Tile> closedTiles = new List<Tile>();

            openTiles.Add(start);

            while (openTiles.Count > 0)
            {
                Tile currentTile = openTiles[0];

                for (int i = 0; i < openTiles.Count; i++)
                {
                    if (openTiles[i].F < currentTile.F
                        || openTiles[i].F == currentTile.F
                        && openTiles[i].H < currentTile.H)
                    {
                        currentTile = openTiles[i];
                    }
                }

                openTiles.Remove(currentTile);
                closedTiles.Add(currentTile);

                if (currentTile == target)
                {
                    RetracePath(start, target);
                    return path;
                }

                foreach(Tile neighbor in currentTile.FindTileNeighbors())
                {
                    //TODO проверка на проходимость
                    if (neighbor != null || closedTiles.Contains(neighbor)) continue;

                    int newMovementCost = neighbor.G + GetDistance(currentTile, neighbor);

                    if(newMovementCost < neighbor.G
                        || !openTiles.Contains(neighbor))
                    {
                        neighbor.G = newMovementCost;
                        neighbor.H = GetDistance(neighbor, target);
                        neighbor.previousTile = currentTile;

                        if (!openTiles.Contains(neighbor))
                        {
                            openTiles.Add(neighbor);
                        }
                    }
                }
            }

            for(int i = 0; i < openTiles.Count; i++)
            {
                path[i] = openTiles[i];
            }

            return path;
        }
    }
}
