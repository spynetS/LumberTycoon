using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [System.Serializable]
    public class Stack

    {
    public int stackSize = 10;
    public List<GameObject> items = new List<GameObject>();


    public GameObject getFirst()
    {
        return items[0];
    }

    }
}