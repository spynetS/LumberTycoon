using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerInventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;
    public UIDocument inventory;

    public void toggleCanvas()
    {   
        transform.GetComponent<Canvas>().enabled = !transform.GetComponent<Canvas>().enabled;
    }

    private void Start()
    {
    }

    void Update()
    {
        // turn on invetory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            VisualElement e = inventory.rootVisualElement.Q("Container");
            e.style.display = e.style.display == DisplayStyle.Flex ? DisplayStyle.None : DisplayStyle.Flex;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = !Cursor.visible;
            //toggleCanvas(); 
        }
    }
}
