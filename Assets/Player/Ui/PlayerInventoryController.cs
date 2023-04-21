using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryController : MonoBehaviour
{
    public GameObject inventoryPanel;

    public void toggleCanvas()
    {   
        transform.GetComponent<Canvas>().enabled = !transform.GetComponent<Canvas>().enabled;
    }
    
    void Update()
    {
        // turn on invetory
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = inventoryPanel.activeSelf;
            toggleCanvas(); 
        }
    }
}
