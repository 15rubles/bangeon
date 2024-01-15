using System;
using System.Collections.Generic;
using Component;
using UnityEngine;

namespace Tiles
{
    [Serializable]
    public class Tile
    {
        public int x;
        public int z; 
        public Tile left;
        public Tile right;
        public Tile back;
        public Tile front;

        public int F;
        public int G;
        public int H;
        public Tile position;
        public Tile targetPosition;
        public Tile previousTile;//для поиска пути, мб куда-то перенести пока хз
        
        public Tile(int x, int z, Tile left, Tile right, Tile back, Tile front)
        {
            this.x = x;
            this.z = z;
            this.left = left;
            this.right = right;
            this.back = back;
            this.front = front;
        }

        public Tile(int x, int z)
        {
            this.x = x;
            this.z = z;
        }

        public Tile()
        { 
            x = 0;
            z = 0;
        }

        public Tile(Tile start, Tile target, Tile previousTile, int g)
        {
            position = start;
            targetPosition = target;
            G = g;
            H = (int) Mathf.Abs(start.x - target.x) + (int)Mathf.Abs(start.z - target.z);
            F = G + H;
        }

        public bool IsPassable()
        {
            return true;
        }
        
        public List<Tile> FindTileNeighbors()
        {
            List<Tile> tiles = new List<Tile>{front, back, left, right};
            tiles.RemoveAll(item => item == null);
            return tiles;
        }

        public Direction TileNeighborDirection(Tile tileForCheck)
        {
            if (tileForCheck == front)
            {
                return Direction.Front;
            }
            if (tileForCheck == back)
            {
                return Direction.Back;
            }
            if (tileForCheck == left)
            {
                return Direction.Left;
            }
            if (tileForCheck == right)
            {
                return Direction.Right;
            }
            return Direction.Undefined;
        }
    }
}