using Assets.Scripts.Enemies;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Rooms
{
    public class Room : ScriptableObject
    {
        [SerializeField] private GameObject roomPrefab;
        [SerializeField] private int level;
        [SerializeField] private List<Enemy> enemies;
    }
}
