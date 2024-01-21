using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tool
{
    public struct TilemapGameObject
    {
        public int x;
        public int y;
        public GameObject obj;

        public TilemapGameObject(int x, int y, GameObject obj)
        {
            this.x = x;
            this.y = y;
            this.obj = obj;
        }
    }

    public static class TilemapTools
    {

        public static List<TilemapGameObject> GetAllGameObjectsFromTiles(Tilemap tilemap)
        {
            BoundsInt bounds = tilemap.cellBounds;

            List<TilemapGameObject> gameObjects = new List<TilemapGameObject>();
            for (int x = bounds.xMin; x < bounds.xMax; x++)
            {
                for (int y = bounds.yMin; y < bounds.yMax; y++)
                {
                    GameObject obj = tilemap.GetInstantiatedObject(new Vector3Int(x, y, 0));
                    if (obj != null)
                    {
                        TilemapGameObject tilemapObj = new TilemapGameObject(x, y, obj);

                        gameObjects.Add(tilemapObj);
                    }
                }
            }


            return gameObjects;
        }

    }
}