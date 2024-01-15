﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Tiles;
using System.Linq;

namespace Assets.Scripts.TileObjects.Traps
{
    public class Saw : Trap
    {
        [SerializeField] private Tile startTile;
        [SerializeField] private Tile endTile;
        [SerializeField] private int deltaX, deltaZ;

        private const double TOLERANCE = 0.1f;

        public override void InitCurrentTile(List<Tile> tiles)
        {
            //TODO init currentTile пока что хардкод
            currentTile = tiles
                .FirstOrDefault(lTile => Math.Abs(lTile.x - gameObject.transform.position.x) < TOLERANCE
                                         && Math.Abs(lTile.z - gameObject.transform.position.z) < TOLERANCE);
            
            startTile = tiles.Find(lTile => lTile.x == startTile.x && startTile.z == lTile.z);
            endTile = tiles.Find(lTile => lTile.x == endTile.x && endTile.z == lTile.z);
        }

        public override TileObjectAction CalculateNextAction(List<Tile> tiles, Tile currentPlayerTile)
        {
            deltaX = startTile.x - endTile.x;
            deltaZ = startTile.z - endTile.z;

            if (currentTile == endTile)
            {
                Tile temp = new Tile();
                temp = startTile;
                startTile = endTile;
                endTile = temp;
            }
            else
            {
                if (deltaX == 0 || deltaZ == 0)
                {
                    if (deltaX < 0)
                    {
                        _nextAction = TileObjectAction.MoveRight;
                    }
                    else if (deltaX > 0)
                    {
                        _nextAction = TileObjectAction.MoveLeft;
                    }

                    if (deltaZ < 0)
                    {
                        _nextAction = TileObjectAction.MoveFront;
                    }
                    else if (deltaZ > 0)
                    {
                        _nextAction = TileObjectAction.MoveBack;
                    }
                }
                else
                {
                    _nextAction = TileObjectAction.Stand;
                }
            }

            if (currentTile == currentPlayerTile)
            {
                _nextAction = TileObjectAction.Attack;
            }

            return _nextAction;
        }

        public override void DoNextAction(List<Tile> tiles, Tile currentPlayerTile)
        {
            if (_nextAction == TileObjectAction.Undefined)
            {
                _nextAction = CalculateNextAction(tiles, currentPlayerTile);
            }

            Vector3 move = Vector3.zero;
            switch (_nextAction)
            {
                case TileObjectAction.Stand:
                    break;
                case TileObjectAction.MoveFront:
                    currentTile = currentTile.front;
                    move += new Vector3(0, 0, 2);
                    break;
                case TileObjectAction.MoveBack:
                    currentTile = currentTile.back;
                    move += new Vector3(0, 0, -2);
                    break;
                case TileObjectAction.MoveLeft:
                    currentTile = currentTile.left;
                    move += new Vector3(-2, 0, 0);
                    break;
                case TileObjectAction.MoveRight:
                    currentTile = currentTile.right;
                    move += new Vector3(2, 0, 0);
                    break;
                case TileObjectAction.Attack:
                    Debug.Log("Saw Attacked");
                    break;
            }

            transform.position += move;
        }
    }
}