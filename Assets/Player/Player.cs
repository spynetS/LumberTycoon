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
            mytext.text = inventory.stacks.Count.ToString();
        }

        private void OnTriggerEnter(Collider other)
        {
            try
            {
                if (other.GetComponent<Mechine.Input>() != null)
                {
                    other.GetComponent<Mechine.Input>().getItem(inventory.stacks[0].items[0]);
                    inventory.remove(inventory.stacks[0].items[0]);
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