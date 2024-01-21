using Entity.Tile;
using UnityEngine;

namespace Tilemap3D.Brushs
{
    [CreateAssetMenu(fileName = "FallingNumberPrefabBrush", menuName = "Brush/FallingNUmberPrefabBrush")]
    [CustomGridBrush(false, true, false, "FallingNumberPrefabBrush")]
    public class FallingNumberPrefabBrush : PrefabBrush
    {
        public int fallingNumber;

        public override void Paint(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
        {
            foreach (BrushCell brushCell in cells)
            {
                FallingNumber fallingNumberObj = brushCell.gameObject.GetComponent<FallingNumber>();
                if (fallingNumberObj != null) fallingNumberObj.fallingNumber = fallingNumber;
            }

            base.Paint(gridLayout, brushTarget, position);
        }
    }
}