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
        public Dictionary<string, int> balleKlaa = new Dictionary<string, int>()
        {
            {"wooddroped",10},
            
        };

        public int stackSize = 3;
        
        public void add(GameObject ob)
        {
            foreach (Stack stack in stacks)
            {
                if (stack.getFirst().CompareTag(ob.tag))
                {
                    if (stack.items.Count < stack.stackSize)
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
                if (stack.getFirst().CompareTag(ob.tag))
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