using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI_Toolkit
{
    public class Inventory
    {
        public UIDocument uiDocument;

        public void Start()
        {
            VisualElement parentElement = uiDocument.rootVisualElement.Q("list");

            if (parentElement != null)
            {
                // Get all child elements within the parent element
                List<VisualElement> childElements = parentElement.Query(null).ToList();

                // Loop through each child element
                foreach (VisualElement child in childElements)
                {
                    // Do something with each child element
                    Debug.Log("Child element found: " + child.name);
                }
            }
        }

    }
}