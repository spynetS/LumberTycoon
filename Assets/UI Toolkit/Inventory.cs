using System;
using System.Collections.Generic;
using Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

namespace UI_Toolkit
{
    public class Inventory : MonoBehaviour
    {
        public UIDocument uiDocument;
        public Sprite empty;
        public Player.Inventory inventory;
        public List<Button> stacks = new List<Button>();
        public Player.Player player;
        public void Start()
        {
            VisualElement parentElement = uiDocument.rootVisualElement.Q("list");

            if (parentElement != null)
            {
                // Get all child elements within the parent element
                List<Button> childElements = parentElement.Query<Button>().ToList();
                foreach (Button child in childElements)
                {
                    if (child.name != "list" && child.name != "label")
                    {
                        //child.style.backgroundImage = new StyleBackground(empty);
                        child.RegisterCallback<ClickEvent>(DropItem); 
                        stacks.Add(child); 
                    }
                }
            }
        } 
        public void Update()
        {
            reset();
            for (int i = 0; i < inventory.stacks.Count; i++)
            {
                stacks[i].style.backgroundImage = new StyleBackground(inventory.stacks[i].getFirst().GetComponent<DroppedItem>().inventoryImage);
                stacks[i].text = inventory.stacks[i].items.Count.ToString();
            }
        }

        public void reset()
        {
            foreach (Button child in stacks)
            { 
                child.style.backgroundImage = new StyleBackground(empty);
            }
        }
        public void DropItem(ClickEvent evt)
        {
            Button clickedButton = (Button)evt.target;
            for (int i = 0; i < inventory.stacks.Count; i++)
            {
                if (new StyleBackground(inventory.stacks[i].getFirst().GetComponent<DroppedItem>().inventoryImage) ==
                    clickedButton.style.backgroundImage)
                {
                    player.dropItem(inventory.stacks[i].getFirst());
                    reset();
                    break;
                }
            }
            
        }
        
    }
}