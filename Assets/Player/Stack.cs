using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [System.Serializable]
    public class Stack 

    {
        public int stackSize = 5;
        public List<GameObject> items = new List<GameObject>();


        public GameObject getFirst()
        {
            return items.Count > 0 ? items[0] : null;
        }

    }
}