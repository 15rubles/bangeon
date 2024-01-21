using Entity.Tile;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tilemap3D
{
    [CreateAssetMenu(fileName = "FallingNumbersBrush", menuName = "FallingNumbersBrush")]
    [CustomGridBrush(false, true, false, "FallingNumbersBrush")]
    public class FallingNumbersBrush : GridBrush
    {
        [SerializeField] private int fallingNumber;
        public override void Paint(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
        {
            base.Paint(gridLayout, brushTarget, position);
            Tilemap tilemap = brushTarget.GetComponent<Tilemap>();
            GameObject obj = tilemap.GetInstantiatedObject(position);
            if (obj != null)
            {
                FallingNumber number = obj.GetComponent<FallingNumber>();
                if (number != null)
                {
                    number.fallingNumber = fallingNumber;
                }
            }
        }
    }
}