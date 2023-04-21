using System;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Ui
{
    public class Itemholder : MonoBehaviour
    {
        public Stack stack;
        public Player player;
        public void dropStack()
        {
            if (stack != null)
            {
                player.dropItem(stack.items[0]);
            }
        }

        private void Update()
        {
            try
            {
                Image image = transform.GetChild(0).gameObject.GetComponent<Image>();
                image.sprite = stack != null ? stack.items[0].GetComponent<DroppedItem>().inventoryImage : null;
                
                TMP_Text mytext = transform.GetChild(1).GetComponent<TMP_Text>();
                mytext.text = stack != null? stack.items.Count.ToString() : "";
            }
            catch (Exception e) { }
            
        }

        public void setStack(in Stack stack)
        {
            this.stack = stack; 
        }
        
    }
}