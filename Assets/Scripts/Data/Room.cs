using System.Collections.Generic;
using Entity.TileObject.Enemy;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Room", menuName = "Data/Room", order = 1)]
    public class Room : ScriptableObject
    {
        public GameObject roomPrefab;
        public int level;
        public List<Enemy> enemies;
    }
}
