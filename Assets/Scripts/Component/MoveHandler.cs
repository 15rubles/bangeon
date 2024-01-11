using System;
using System.Collections.Generic;
using System.Linq;
using Tiles;
using UnityEngine;

namespace Component
{
    public class MoveHandler: MonoBehaviour
    {
        [SerializeField] private GameController _gameController;
        private List<Tile> _tiles;
        public Tile currentTile;

        void Start()
        {
            _tiles = _gameController.tiles;
            currentTile =  _tiles
                .FirstOrDefault(lTile => lTile.x == 0 && lTile.z == 0);
        }

        public bool IsTargetTilePassable(Direction direction)
        {
            int x = currentTile.x, z = currentTile.z;
            switch (direction)
            {
                case Direction.Front:
                    z += 2;
                    break;
                case Direction.Back:
                    z -= 2;
                    break;
                case Direction.Left:
                    x -= 2;
                    break;
                case Direction.Right:
                    x += 2;
                    break;
            }
            
            Tile tile = _tiles
                .FirstOrDefault(lTile => lTile.x == x && lTile.z == z);

            if (tile == null)
            {
                return false;
            }

            if (tile.IsPassable())
            {
                currentTile = tile;
                return true;
            }

            return false;
        }
    }
}