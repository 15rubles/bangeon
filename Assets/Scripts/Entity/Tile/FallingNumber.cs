using TMPro;
using UnityEngine;

namespace Entity.Tile
{
    [ExecuteInEditMode]
    public class FallingNumber : MonoBehaviour
    {
        public int fallingNumber;
        [SerializeField] private TMP_Text fallingNumberText;

        private void Update()
        {
            fallingNumberText.text = fallingNumber.ToString();
        }
    }
}