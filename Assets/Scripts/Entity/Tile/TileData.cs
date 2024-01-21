using System;
using Common;
using Entity.TileObject;
using Tool;
using UnityEngine;

namespace Entity.Tile
{
    [Serializable]
    public class TileNeighbors
    {
        public TileImpl Left;
        public TileImpl Right;
        public TileImpl Back;
        public TileImpl Front;

        public TileNeighbors(TileImpl left, TileImpl right, TileImpl back, TileImpl front)
        {
            Left = left;
            Right = right;
            Back = back;
            Front = front;
        }

    }

    [Serializable]
    public class TileData
    {
        [ReadOnly] [SerializeField] private Vector2Int coordinates;
        [ReadOnly] [SerializeField] private bool isPassable;
        [ReadOnly] [SerializeField] private TileNeighbors neighbors;
        [ReadOnly] [SerializeReference] private ITileObject tileObject;
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