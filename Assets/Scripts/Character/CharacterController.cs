using System;
using Component;
using UnityEngine;

namespace Character
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private MoveHandler _moveHandler;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (_moveHandler.IsTargetTilePassable(Direction.Front))
                {
                    gameObject.transform.position += new Vector3(0, 0, 2);
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (_moveHandler.IsTargetTilePassable(Direction.Left))
                {
                    gameObject.transform.position += new Vector3(-2, 0, 0);
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (_moveHandler.IsTargetTilePassable(Direction.Back))
                {
                    gameObject.transform.position += new Vector3(0, 0, -2);
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (_moveHandler.IsTargetTilePassable(Direction.Right))
                {
                    gameObject.transform.position += new Vector3(2, 0, 0);
                }
            }
        }
    }
}