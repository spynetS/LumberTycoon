using System;
using System.Collections.Generic;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI_Toolkit
{
    public class Inventory : MonoBehaviour
    {
        public UIDocument uiDocument;
        public Sprite empty;
        public Player.Inventory inventory;
        public List<VisualElement> stacks = new List<VisualElement>();
        public void Start()
        {
            VisualElement parentElement = uiDocument.rootVisualElement.Q("list");

            if (parentElement != null)
            {
                // Get all child elements within the parent element
                List<VisualElement> childElements = parentElement.Query(null).ToList();
                foreach (VisualElement child in childElements)
                {
                    if (child.name != "list" && child.name != "label")
                    {
                        //child.style.backgroundImage = new StyleBackground(empty);
                        stacks.Add(child); 
                    }
                }
            }
        } 
        public void Update()
        {
            for (int i = 0; i < inventory.stacks.Count; i++)
            {
                stacks[i].style.backgroundImage = new StyleBackground(inventory.stacks[i].getFirst().GetComponent<DroppedItem>().inventoryImage);
                Label childLabel = stacks[i].Q<Label>();
                childLabel.text = inventory.stacks[i].items.Count.ToString();

            }
        }
        
        
        
    }
}