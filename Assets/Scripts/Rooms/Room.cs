using System.Collections.Generic;
using Assets.Scripts.Enemies;
using UnityEngine;

namespace Rooms
{
    [CreateAssetMenu(fileName = "Room", menuName = "Data/Room", order = 1)]
    public class Room : ScriptableObject
    {
        public GameObject roomPrefab;
        public int level;
        public List<Enemy> enemies;
    }
}
