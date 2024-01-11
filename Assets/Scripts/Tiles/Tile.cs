using System;
using Unity.VisualScripting;
using UnityEngine.Serialization;

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


        public bool IsPassable()
        {
            return true;
        }
    }
}