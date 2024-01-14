using Component;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiles;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    public class Shy : Enemy
    {
        [SerializeField] private GameController gameController;

        private List<Tile> _tiles;

        [SerializeField] private Tile leftTile;
        [SerializeField] private Tile rightTile;
        [SerializeField] private Tile frontTile;
        [SerializeField] private Tile backTile;

        private Vector3 pos;
        private Vector3 playerPos;

        private bool isPlayerMoved = false;//костыль

        private void Start()
        {
            _tiles = gameController.tiles;
            //playerPos = player.transform.position;
        }

        public override EnemyAction CalculateNextAction(List<Tile> tiles, Tile currentPlayerTile)
        {
            // if (leftTile != null
            //     || rightTile != null
            //     || frontTile != null
            //     || backTile != null)
            // {
            //     if (leftTile == player.GetComponent<MoveHandler>().currentTile)
            //     {
            //         return EnemyAction.MoveRight;
            //     }
            //     if (rightTile == player.GetComponent<MoveHandler>().currentTile)
            //     {
            //         return EnemyAction.MoveLeft;
            //     }
            //     if (frontTile == player.GetComponent<MoveHandler>().currentTile)
            //     {
            //         return EnemyAction.MoveBack;
            //     }
            //     if (backTile == player.GetComponent<MoveHandler>().currentTile)
            //     {
            //         return EnemyAction.MoveFront;
            //     }
            // }
            // //else
            // //{
            // //    if (currentTile.x == 20 || currentTile.x == 0)
            // //    {
            // //        if (leftTile == player.GetComponent<MoveHandler>().currentTile || rightTile == player.GetComponent<MoveHandler>().currentTile)
            // //        {
            // //            switch (RandomFrontBack())
            // //            {
            // //                case 0: return Actions.MoveFront;
            // //                case 1: return Actions.MoveBack;
            // //            }
            // //        }
            // //    }
            // //    if (frontTile.front == null || backTile.back == null)
            // //    {
            // //        if (frontTile == player.GetComponent<MoveHandler>().currentTile || backTile == player.GetComponent<MoveHandler>().currentTile)
            // //        {
            // //            switch (RandomRightLeft())
            // //            {
            // //                case 0: return Actions.MoveLeft;
            // //                case 1: return Actions.MoveRight;
            // //            }
            // //        }
            // //    }
            // //}
            // return EnemyAction.Stand;
            return 0;
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
        // if (CalculateNextAction() == EnemyAction.MoveRight)
        // {
        //     transform.position += new Vector3(2, 0, 0);
        // }
        // if (CalculateNextAction() == EnemyAction.MoveLeft)
        // {
        //     transform.position += new Vector3(-2, 0, 0);
        // }
        // if (CalculateNextAction() == EnemyAction.Stand)
        // {
        //     transform.position += Vector3.zero;
        // }
    }

    public int RandomRightLeft()
    {
        int choice = Random.Range(0, 2);
        return choice;
    }

    public int RandomFrontBack()
    {
        int choice = Random.Range(0, 2);
        return choice;
    }
}
}
