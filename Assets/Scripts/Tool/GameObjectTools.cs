using System.Collections.Generic;
using UnityEngine;

namespace Tool
{
    public static class GameObjectTools
    {
        public static List<GameObject> GetAllChildren(GameObject gameObject)
        {
            int children = gameObject.transform.childCount;
            List<GameObject> childrens = new List<GameObject>();
            for (int i = 0; i < children; ++i)
            {
                childrens.Add(gameObject.transform.GetChild(i).gameObject);
            }
            return childrens;
        }
    }
}