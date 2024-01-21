using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public enum Direction
    {
        Front,
        Back,
        Right,
        Left
    }

    public static class DirectionTolls
    {
        public static Direction ToDirection(this Vector2Int vec)
        {
            switch ((vec.x, vec.y))
            {
                case (0, 1):
                    return Direction.Front;
                case (0, -1):
                    return Direction.Back;
                case (1, 0):
                    return Direction.Right;
                case (-1, 0):
                    return Direction.Left;
                default:
                    throw new ArgumentException("illegal vector");
            }
        }

        public static Vector2Int ToVector2Int(this Direction direction)
        {
            switch (direction)
            {
                case Direction.Front:
                    return Vector2Int.up;
                case Direction.Back:
                    return Vector2Int.down;
                case Direction.Right:
                    return Vector2Int.right;
                case Direction.Left:
                    return Vector2Int.left;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }


        public static List<Direction> GetDirectionCircle()
        {
            return new List<Direction>
            {
                Direction.Front,
                Direction.Back,
                Direction.Left,
                Direction.Right
            };
        }
    }


}