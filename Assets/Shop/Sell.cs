using System;
using UnityEngine;

namespace Shop
{
    public class Sell : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            DroppedItem i = other.gameObject.GetComponent<DroppedItem>(); 
            if (i != null && i.canSell)
            {
                GameObject.FindWithTag("Player").GetComponent<Player.Player>().money += i.sellAmount;
                other.gameObject.SetActive(false);
            }
        }
    }
}