using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUi : MonoBehaviour
{
    public Inventory inventory;
    public Sprite yourSprite;
    private void Update()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            // Add the sprite to the child
            Transform child = this.transform.GetChild(i);
            // Add the sprite to the child
            Image image = child.gameObject.AddComponent<Image>();
            image.sprite = yourSprite;
        }

    }
}                