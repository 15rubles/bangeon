using System;
using System.Collections.Generic;
using Entity.Tile;
using Entity.TileObject;
using Tool;
using UnityEngine;

namespace Entity.Room
{
    [Serializable]
    public class RoomData
    {
        [SerializeField] private List<TileImpl> tiles;
        [SerializeReference] private List<ITileObject> tileObjects;

        // [InspectorReadOnly] private List<Character> charactersInRoom;
        [SerializeField] private TileImpl startTileImpl;
        [SerializeField] private TileImpl exitTileImpl;
        [SerializeField] private int difficulty;
        [SerializeField] public bool isPassed = false;

        public List<TileImpl> Tiles => tiles;

        public List<ITileObject> TileObjects => tileObjects;

        public TileImpl StartTileImpl => startTileImpl;

        public TileImpl ExitTileImpl => exitTileImpl;

        public int Difficulty => difficulty;

        public RoomData(List<TileImpl> tiles, List<ITileObject> tileObjects, TileImpl startTileImpl, TileImpl exitTileImpl,
            int difficulty)
        {
            this.tiles = tiles;
            this.tileObjects = tileObjects;
            this.startTileImpl = startTileImpl;
            this.exitTileImpl = exitTileImpl;
            this.difficulty = difficulty;
        }
    }
}