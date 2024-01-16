using System;
using System.Collections.Generic;
using Common;

namespace Entity.Tile
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

        public bool isPassable;

        public Tile(int x, int z, Tile left, Tile right, Tile back, Tile front, bool isPassable)
        {
            this.x = x;
            this.z = z;
            this.left = left;
            this.right = right;
            this.back = back;
            this.front = front;
            this.isPassable = true;
        }

        public Tile(int x, int z, bool isPassable)
        {
            this.x = x;
            this.z = z;
            this.isPassable = isPassable;
        }

        public Tile()
        { 
            x = 0;
            z = 0;
            isPassable = true;
        }

        public bool IsPassable()
        {
            return isPassable;
        }
        
        public List<Tile> GetTileNeighbors()
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