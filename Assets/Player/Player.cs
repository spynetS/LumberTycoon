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
        private void Update()
        {
        }

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
                    GameObject o = inventory.stacks[0].items[0];
                    // if the item is refineable
                    if (o.GetComponent<RefineItem>() != null)
                    {
                        other.GetComponent<Mechine.Input>().getItem(o);
                        inventory.remove(o);
                    }
                }
            } catch{}

            if (other.GetComponent<DroppedItem>() != null)
                inventory.add(other.gameObject);

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