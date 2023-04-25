using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


namespace Player
{
    public class Inventory : MonoBehaviour
    {
        public List<Stack> stacks = new List<Stack>();
        // define how many of a droped item can stack (item tag)(stackamount)
        public Dictionary<string, int> balleKlaa = new Dictionary<string, int>()
        {
            {"wooddroped",10},
            {"stonedroped",5},
            
        };

        public int stackSize = 3;
        
        public void add(GameObject ob)
        {
            foreach (Stack stack in stacks)
            {
                if (stack.getFirst().GetComponent<DroppedItem>().name == ob.GetComponent<DroppedItem>().name)
                {
                    if (stack.items.Count < stack.stackSize && stacks.Count <= stackSize)
                    {
                        stack.items.Add(ob);
                        ob.SetActive(false);
                        return;
                    }
                }
            }

            if (stacks.Count < stackSize)
            {
                Stack s = new Stack();
                s.items.Add(ob);
                s.stackSize = balleKlaa[ob.tag];
                
                ob.SetActive(false);

                stacks.Add(s);
            }
        }

        public void remove(GameObject ob)
        {
            foreach (Stack stack in stacks)
            {
                    Debug.Log(stack.items);
                if (stack.getFirst().GetComponent<DroppedItem>().name == ob.GetComponent<DroppedItem>().name)
                {
                    stack.items.Remove(ob);
                    if (stack.items.Count == 0)
                    {
                        stacks.Remove(stack);
                    }
                }
            }
        }
    }
}