using System.Collections.Generic;
using System.Linq;
using Common;
using Entity.Room;
using Entity.Tile;
using Entity.TileObject;
using Tool;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

namespace Tilemap3D
{
    public class RoomMapper : MonoBehaviour
    {
        [SerializeField] private Tilemap tilemapFloor;
        [SerializeField] private Tilemap tilemapTileObjects;
        [SerializeField] private Tilemap tilemapFallingNumbers;
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

            tilemapObjects = TilemapTools.GetAllGameObjectsFromTiles(tilemapFallingNumbers);

            foreach (TilemapGameObject tilemapObj in tilemapObjects)
            {
                FallingNumber number = tilemapObj.obj.GetComponent<FallingNumber>();
                if (number != null)
                {
                    TileImpl tile = GetTileByCoordinates(new Vector2Int(tilemapObj.x, tilemapObj.y), tiles);
                    if (tile != null)
                    {
                        tile.TileData.FallingTurn = number.fallingNumber;
                    }
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
                neighbors.neighborsByDirection = new Dictionary<Direction, TileImpl>();
                foreach (Direction direction in DirectionTolls.GetDirectionCircle())
                {
                    neighbors.neighborsByDirection[direction] =
                        GetTileByCoordinates(coordinates + direction.ToVector2Int(), tiles);
                }
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