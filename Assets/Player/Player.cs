using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Mechine;
using Unity.VisualScripting;

namespace Player{

    public class Player : MonoBehaviour
    {
        public TMP_Text mytext;
        public Inventory inventory;
        public PlayerMovement playerMovement;
        public float money = 10000;
        private void Update()
        {
            mytext.text = money.ToString();
            if (isDead)
            {
                foreach(Stack stack in inventory.stacks)
                {
                    stack.dropAll(transform);
                }

                inventory.stacks.Clear();

                if (inventory.stacks.Count == 0)
                {
                    isDead = false;
                    transform.position = new Vector3(0, 10, 0);
                }
            }
        }

        public bool isDead = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Output>() != null)
            {
                Output o = other.GetComponent<Output>();
                foreach (GameObject g in o.items)
                {
                    Debug.Log(g);
                    inventory.add(g);
                }
                o.items.Clear();
            }
            try
            {
                if (other.GetComponent<Mechine.Input>() != null)
                {
                    GameObject o = inventory.getResorceItem();
                        // if the item is refineable
                    if (o.GetComponent<RefineItem>() != null)
                    {
                        int i = 0;
                        while (i < 1000)
                        {
                            if (o != null)
                            {
                                other.GetComponent<Mechine.Input>().getItem(o);
                                inventory.remove(o);
                                
                            }
                            i++;
                            o = inventory.getResorceItem();
                        }
                    }
                }
            } catch{}

            if (other.GetComponent<DroppedItem>() != null)
                inventory.add(other.gameObject);

            if (other.transform.tag == "stone")
            {
                isDead = true;
            }
        }
        
        public void dropItem(GameObject ob)
        {
            ob.transform.position = transform.position + (transform.forward * 5);
            ob.SetActive(true);
            ob.GetComponent<DroppedItem>().drop();
            inventory.remove(ob);
        }
    }
}