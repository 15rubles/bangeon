using System.Collections.Generic;
using System.Linq;
using Common;
using Entity.Room;
using Entity.Tile;
using Entity.TileObject;
using Tool;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tilemap3D
{
    public class RoomMapper : MonoBehaviour
    {
        [SerializeField] private Tilemap tilemapFloor;
        [SerializeField] private Tilemap tilemapTileObjects;
        [SerializeField] private Tilemap fallingNumbers;
        [SerializeField] private int difficulty;
        [SerializeReference] private IRoom room;

        private void Start()
        {
            room = GenerateRoom();
            Debug.Log("ert");
        }

        public IRoom GenerateRoom()
        {
            List<TileImpl> tiles = new List<TileImpl>();
            List<ITileObject> tileObjects = new List<ITileObject>();

            List<TilemapGameObject> tilemapObjects = TilemapTools.GetAllGameObjectsFromTiles(tilemapFloor);

            foreach (TilemapGameObject tilemapObj in tilemapObjects)
            {
                TileImpl tile = tilemapObj.obj.GetComponent<TileImpl>();
                tile.TileData.Coordinates = new Vector2Int(tilemapObj.x, tilemapObj.y);
                tiles.Add(tile);
            }

            ConnectNeighbours(tiles);

            tilemapObjects = TilemapTools.GetAllGameObjectsFromTiles(tilemapTileObjects);

            foreach (TilemapGameObject tilemapObj in tilemapObjects)
            {
                ITileObject tileObject = tilemapObj.obj.GetComponent<ITileObject>();
                if (tileObject != null)
                {
                    TileImpl tile = GetTileByCoordinates(new Vector2Int(tilemapObj.x, tilemapObj.y), tiles);
                    tile.TileData.TileObject = tileObject;
                    tileObjects.Add(tileObject);
                }
            }

            return new FightRoom(new RoomData(tiles, tileObjects, FindFirstByTileType(TileType.Start, tiles),
                FindFirstByTileType(TileType.End, tiles), difficulty));
        }

        private void ConnectNeighbours(List<TileImpl> tiles)
        {
            foreach (TileImpl tile in tiles)
            {
                Vector2Int coordinates = tile.TileData.Coordinates;
                TileNeighbors neighbors = tile.TileData.Neighbors;
                neighbors.Front = GetTileByCoordinates(coordinates + Vector2Int.up, tiles);
                neighbors.Back = GetTileByCoordinates(coordinates + Vector2Int.down, tiles);
                neighbors.Left = GetTileByCoordinates(coordinates + Vector2Int.left, tiles);
                neighbors.Right = GetTileByCoordinates(coordinates + Vector2Int.right, tiles);
            }
        }


        private TileImpl GetTileByCoordinates(Vector2Int coordinates, List<TileImpl> tiles)
        {
            return tiles.FirstOrDefault(tile => tile.TileData.Coordinates == coordinates);
        }

        private TileImpl FindFirstByTileType(TileType type, List<TileImpl> tiles)
        {
            return tiles.FirstOrDefault(tile => tile.TileData.TileType == type);
        }

    }
}