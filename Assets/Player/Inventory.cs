using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


namespace Player
{

    public class Inventory : MonoBehaviour
    {
        public List<Stack> stacks = new List<Stack>();

        public int stackSize = 3;

        // Update is called once per frame
        public void add(GameObject ob)
        {
            foreach (Stack stack in stacks)
            {
                if (stack.getFirst().tag == ob.tag)
                {
                    if(stack.items.Count < stack.stackSize) stack.items.Add(ob);
                    return;
                }
            }

            Stack s = new Stack();
            s.items.Add(ob);

            stacks.Add(s);
        }

        public void remove(GameObject ob)
        {
            
        }
    }
    
}