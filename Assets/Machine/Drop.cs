using System;
using System.Collections;
using System.Collections.Generic;
using Mechine;
using Player;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Inventory inventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        Machine machine = GameObject.FindWithTag("Machine").GetComponent<Machine>();
        
        RefineItem item = other.GetComponent<RefineItem>();
        if (item != null && machine.input.items.Count < machine.input.maxRefineItems)
        {
                machine.input.getItem(item.gameObject);
                other.gameObject.SetActive(false);
        }
        
    }
}
