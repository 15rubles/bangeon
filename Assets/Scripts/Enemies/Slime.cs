using Component;
using System.Collections.Generic;
using System.Linq;
using Tiles;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Slime : Enemy
    {
        [SerializeField] private GameController gameController;

        private List<Tile> _tiles;
        [SerializeField] private Tile currentTile;
        private Vector3 pos;
        private Vector3 playerPos;

        private bool isPlayerMoved = false;//костыль

        private void Start()
        {
            _tiles = gameController.tiles;
            playerPos = player.transform.position;
        }

        private void Update()
        {
            if (playerPos != player.transform.position)
            {
                isPlayerMoved = true;
                playerPos = player.transform.position;
            }
            if (isPlayerMoved)
            {
                DoNextAction();
                isPlayerMoved = false;
            }
            
            pos = transform.position;
            currentTile = _tiles
                .FirstOrDefault(lTile => lTile.x == pos.x && lTile.z == pos.z);
        }

        public override Actions CalculateNextAction()
        {
            if (player.GetComponent<MoveHandler>().currentTile == currentTile)
            {
                return Actions.Attack;
            }
            else
            {
                int actionMove = Random.Range(0, 5);
                switch (actionMove)
                {
                    case 0:
                        if (pos.z + 2 <= 20)
                        {
                            return Actions.MoveFront;
                        }
                        break;
                    case 1:
                        if (pos.z - 2 > 0)
                        {
                            return Actions.MoveBack;
                        }
                        break;
                    case 2:
                        if (pos.x + 2 <= 20)
                        {
                            return Actions.MoveRight;
                        }
                        break;
                    case 3:
                        if (pos.x - 2 > 0)
                        {
                            return Actions.MoveLeft;
                        }
                        break;
                }
            }
            return Actions.Stand;
        }

        public override void DoNextAction()
        { 
            if (CalculateNextAction() == Actions.MoveFront)
            {
                transform.position += new Vector3(0, 0, 2);
            }
            if (CalculateNextAction() == Actions.MoveBack)
            {
                transform.position += new Vector3(0, 0, -2);
            }
            if (CalculateNextAction() == Actions.MoveLeft)
            {
                transform.position += new Vector3(-2, 0, 0);
            }
            if (CalculateNextAction() == Actions.MoveRight)
            {
                transform.position += new Vector3(2, 0, 0);
            }
            if (CalculateNextAction() == Actions.Stand)
            {
                transform.position += Vector3.zero;
            }
            if(CalculateNextAction() == Actions.Attack)
            {
                Debug.Log("Slime Attacked");
            }
        }
    }
}
