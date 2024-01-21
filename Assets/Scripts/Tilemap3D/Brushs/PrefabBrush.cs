using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine;

namespace Tilemap3D.Brushs
{
    [CreateAssetMenu(fileName = "PrefabBrush", menuName = "Brush/PrefabBrush")]
    [CustomGridBrush(false, true, false, "PrefabBrush")]
    public class PrefabBrush : GameObjectBrush
    {
        private const int PALLETS_LAYER = 31;

        public override void Erase(GridLayout gridLayout, GameObject brushTarget, Vector3Int position)
        {
            if (brushTarget.layer == PALLETS_LAYER) return;

            Transform erased = GetObjectInCell(gridLayout, brushTarget.transform,
                new Vector3Int(position.x, position.y, 0));

            if (erased != null) Undo.DestroyObjectImmediate(erased.gameObject);
        }

        private static Transform GetObjectInCell(GridLayout grid, Transform parent, Vector3Int position)
        {
            int childCount = parent.childCount;
            Vector3 min = grid.LocalToWorld(grid.CellToLocalInterpolated(position));
            Vector3 max = grid.LocalToWorld(grid.CellToLocalInterpolated(position + Vector3Int.one));
            Bounds bounds = new Bounds((max + min) * 0.5f, max - min);

            for (int i = 0; i < childCount; i++)
            {
                Transform child = parent.GetChild(i);
                if (bounds.Contains(child.position)) return child;
            }

            return null;
        }
    }
}