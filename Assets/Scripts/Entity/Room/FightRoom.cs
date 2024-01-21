using System;
using UnityEngine;

namespace Entity.Room
{
    [Serializable]
    public class FightRoom : IRoom
    {
        [SerializeField] private RoomData roomData;

        public void UpdateIsPassed()
        {
            throw new NotImplementedException();
        }

        public RoomData RoomData => roomData;

        public FightRoom(RoomData roomData)
        {
            this.roomData = roomData;
        }
    }
}