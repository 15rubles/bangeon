using UnityEngine;

namespace Data.Config
{
    [CreateAssetMenu(fileName = "GeneralConfig", menuName = "Config/GeneralConfig", order = 1)]
    public class GeneralConfig : ScriptableObject
    {
        public int tileScale;
    }
}