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
                other.GetComponent<Mechine.Input>().getItem(inventory.stacks[0].items[0]);
                inventory.remove(inventory.stacks[0].items[0]);
            } catch{}

            try
            {
                other.GetComponent<DroppedItem>().gameObject.SetActive(false);

                inventory.add(other.gameObject);

            }catch{}
        }
    }
}