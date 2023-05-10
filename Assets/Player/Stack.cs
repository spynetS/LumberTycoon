using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

namespace Player
{
    [System.Serializable]
    public class Stack 
    {
        public int stackSize = 5;
        public List<GameObject> items = new List<GameObject>();

        public bool drop(Transform transform)
        {
            if (items.Count < 1)
            {
                return false;
            }

            items[0].transform.position = transform.position + (transform.forward * 5);
            items[0].SetActive(true);
            items[0].GetComponent<DroppedItem>().drop();
            items.Remove(items[0]);
            
            return true;
        }
        public GameObject getFirst()
        {
            return items.Count > 0 ? items[0] : null;
        }

    }
}