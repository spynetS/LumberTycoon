using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using Player.Ui;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUi : MonoBehaviour
{
    public Inventory inventory;
    public Sprite yourSprite;
    public GameObject inventoryPanel;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryPanel.GetComponent<Canvas>().enabled = !inventoryPanel.GetComponent<Canvas>().enabled;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = inventoryPanel.GetComponent<Canvas>().enabled;
            
        }
        for (int i = 0; i < this.inventory.stacks.Count; i++)
        {
            // Add the sprite to the child
            Transform child = this.transform.GetChild(i);

            child.GetComponent<Itemholder>().setStack(inventory.stacks[i]);
        }
    }
}                