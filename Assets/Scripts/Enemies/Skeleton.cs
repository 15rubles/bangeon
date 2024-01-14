using Component;
using System;
using System.Collections.Generic;
using System.Linq;
using Tiles;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Skeleton : Enemy
    {
        [SerializeField] private GameController gameController;

        private List<Tile> path;

        private List<Tile> _tiles;
        private Vector3 pos;
        private Vector3 playerPos;

        private bool isPlayerMoved;

        private void Start()
        {
            _tiles = gameController.tiles;
            pos = transform.position;
        }

        public override EnemyAction CalculateNextAction(List<Tile> tiles, Tile currentPlayerTile)
        { 
            //foreach (Vector3 point in path)
            //{
            //    float deltaX = pos.x - point.x;
            //    float deltaZ = pos.z - point.z;

            //    if (deltaX == 0)
            //    {

            //    }
            //}


            if (true)
            {
                return EnemyAction.MoveFront;
            }

        }

        public override void DoNextAction(List<Tile> tiles, Tile currentPlayerTile)
        {
            // if (CalculateNextAction() == EnemyAction.MoveFront)
            // {
            //     transform.position += new Vector3(0, 0, 2);
            // }
            // if (CalculateNextAction() == EnemyAction.MoveBack)
            // {
            //     transform.position += new Vector3(0, 0, -2);
            // }
            // if (CalculateNextAction() == EnemyAction.MoveLeft)
            // {
            //     transform.position += new Vector3(-2, 0, 0);
            // }
            // if (CalculateNextAction() == EnemyAction.MoveRight)
            // {
            //     transform.position += new Vector3(2, 0, 0);
            // }
            // if (CalculateNextAction() == EnemyAction.Stand)
            // {
            //     transform.position += Vector3.zero;
            // }
        }

        public void StartSearch(Tile endTile)
        { 
            Vector3 endTilePosition = new Vector3(endTile.x, 0, endTile.z);

            path = _tiles.OrderBy(x => Vector3.Distance(new Vector3(x.x, 0, x.z), endTilePosition)).ToList();

            Tile startTile = SearchPath(currentTile);

            if(startTile != null)
            {
                path.Add(startTile);
                path.Add(endTile);
            }
        }

        public Tile SearchPath(Tile startTile)
        {
            CompareTiles(startTile);

            for(int i = 0; i < path.Count; i++)
            {
                Tile tile = path[i];

                float distance = Vector3.Distance(new Vector3(startTile.x, 0, startTile.z), new Vector3(tile.x, 0, tile.z));

                if(distance < 1.1f)
                {
                    if(tile == startTile)
                    {
                        return tile;
                    }
                    else
                    {
                        Tile tempTile = SearchPath(tile);
                        if(tempTile != null)
                        {
                            path.Add(tempTile);
                            return tempTile;
                        }
                    }
                }
            }

            return null;
        }

        public void CompareTiles(Tile tile)
        {
            int index = path.IndexOf(tile);
            path.RemoveAt(index);
        }
    }
}
