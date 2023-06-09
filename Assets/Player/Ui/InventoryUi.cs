using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Ui
{
    public class InventoryUi : MonoBehaviour
    {
        public Inventory inventory;
        public Sprite yourSprite;
        public GameObject inventoryPanel;
        private void Update()
        {
           
            //clear stacks
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = this.transform.GetChild(i);
                child.GetComponent<Itemholder>().setStack(null);
            }
            for (int i = 0; i < this.inventory.stacks.Count; i++)
            {
                // Add the sprite to the child
                Transform child = this.transform.GetChild(i);
                child.GetComponent<Itemholder>().setStack(inventory.stacks[i]);
            }
        }
}                
    
}