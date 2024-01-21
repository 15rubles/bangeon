using System;
using System.Collections.Generic;
using Common;
using Entity.TileObject;
using Tool;
using UnityEngine;

namespace Entity.Tile
{
    [Serializable]
    public class TileNeighbors
    {
        public Dictionary<Direction, TileImpl> neighborsByDirection = new Dictionary<Direction, TileImpl>();
        public TileNeighbors(Dictionary<Direction, TileImpl> neighborsByDirection)
        {
            this.neighborsByDirection = neighborsByDirection;
        }

    }

    [Serializable]
    public class TileData
    {
        [SerializeField] private Vector2Int coordinates;
        [SerializeField] private bool isPassable;
        [SerializeField] private TileNeighbors neighbors;
        [SerializeField] private int fallingTurn;
        private ITileObject tileObject;
        [SerializeField] private TileType type;


        public Vector2Int Coordinates
        {
            get => coordinates;
            set => coordinates = value;
        }

        public TileNeighbors Neighbors => neighbors;
        public bool IsPassable => isPassable;

        public ITileObject TileObject
        {
            get => tileObject;
            set => tileObject = value;
        }

        public TileType TileType
        {
            get => type;
            set => type = value;
        }

        public int FallingTurn
        {
            get => fallingTurn;
            set => fallingTurn = value;
        }

        public TileData(Vector2Int coordinates, bool isPassable, TileNeighbors neighbors, TileType type)
        {
            TileType = type;
            this.coordinates = coordinates;
            this.isPassable = isPassable;
            this.neighbors = neighbors;
        }

        public TileData(Vector2Int coordinates, TileType type)
        {
            TileType = type;
            this.coordinates = coordinates;
        }
    }
}