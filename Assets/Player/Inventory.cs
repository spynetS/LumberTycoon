using System;
using System.Collections;
using System.Collections.Generic;
using Mechine;
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
            {"saphire",5},
            {"ruby",5},
            {"stol",2},
            {"train",2},
            {"wagen",2},
            
            {"saphire ore",2},
            {"ruby ore",2},
            {"dia ore",2},
            {"coal ore",2},
            {"stone ore",2},
            {"aluminium ore",2},
            
            
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
                s.stackSize = balleKlaa[ob.GetComponent<DroppedItem>().name];
                
                ob.SetActive(false);

                stacks.Add(s);
            }
        }
        
        public GameObject getResorceItem()
        {
            foreach (Stack stack in stacks)
            {
                if (stack.getFirst().GetComponent<RefineItem>() != null) return stack.getFirst();
            }

            return null;
        }
        
        public void remove(GameObject ob)
        {
            foreach (Stack stack in stacks)
            {
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